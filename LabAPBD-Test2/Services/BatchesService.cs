using LabAPBD_Test2.Data;
using LabAPBD_Test2.DTOs;
using LabAPBD_Test2.Models;
using LabAPBD_Test2.Services.Utils;
using Microsoft.EntityFrameworkCore;

namespace LabAPBD_Test2.Services;

public class BatchesService(DatabaseContext context) : IBatchesService
{
    public async Task<ServiceResult<object>> CreateNewBatch(NewBatchDto newBatchDto)
    {
        await using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            var specie = await context.TreeSpecies
                .FirstOrDefaultAsync(t => t.LatinName == newBatchDto.Species);

            if (specie == null)
                return ServiceResult<object>.FailureResult("SPECIES_NOT_FOUND", "Species not found");
            
            var nursery = await context.Nurseries
                .FirstOrDefaultAsync(t => t.Name == newBatchDto.Nursery);
            
            if (nursery == null)
                return ServiceResult<object>.FailureResult("NURSERY_NOT_FOUND", "Nursery not found");
            
            var empIds = newBatchDto.Responsible.Select(r => r.EmployeeId).ToList();
            
            var hasEmps = await context.Employees
                .Where(e => empIds.Contains(e.EmployeeId))
                .Select(e => e.EmployeeId)
                .ToListAsync();
            
            var missingEmps = empIds.Cast<int>().Except(hasEmps).ToList();
            if (missingEmps.Any())
            {
                return ServiceResult<object>.FailureResult("EMPLOYEE_NOT_FOUND", "Employee by id " + string.Join(",", missingEmps) + " could not be found");
            }

            var newBatch = new SeedlingBatch
            {
                Quantity = (int)newBatchDto.Quantity!,
                TreeSpecies = specie,
                Nursery = nursery,
                SownDate = DateTime.Now,
                ReadyDate = null,
                Responsibles = newBatchDto.Responsible.Select(r => new Responsible
                {
                    EmployeeId = (int)r.EmployeeId!,
                    Role = r.Role
                }).ToList()
            };

            context.SeedlingBatches.Add(newBatch);
            
            await context.SaveChangesAsync();
            await transaction.CommitAsync();

            return ServiceResult<object>.SuccessResult(null!);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
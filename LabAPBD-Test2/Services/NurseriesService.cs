using LabAPBD_Test2.Data;
using LabAPBD_Test2.DTOs;
using LabAPBD_Test2.Services.Utils;
using Microsoft.EntityFrameworkCore;

namespace LabAPBD_Test2.Services;

public class NurseriesService(DatabaseContext context) : INurseriesService
{
    public async Task<ServiceResult<NurseryBatchesDto>> GetBatchesForNurseryById(int nurseryId)
    {
        var nursery = await context.Nurseries.FirstOrDefaultAsync(n => n.NurseryId == nurseryId);

        if (nursery == null)
            return ServiceResult<NurseryBatchesDto>.FailureResult("NURSERY_NOT_FOUND", "The nursery by given Id does not exist");

        var resBatches = await context.SeedlingBatches
            .Where(b => b.NurseryId == nurseryId)
            .Include(b => b.TreeSpecies)
            .Select(b => new BatchDto
            {
                BatchId = b.BatchId,
                Quantity = b.Quantity,
                SownDate = b.SownDate,
                ReadyDate = b.ReadyDate,
                Species = new SpeciesDto
                {
                    LatinName = b.TreeSpecies.LatinName,
                    GrowthTimeInYears = b.TreeSpecies.GrowthTimeInYears
                },
                Responsible = b.Responsibles.Select(r => new ResponsibleDto
                {
                    FirstName = r.Employee.FirstName,
                    LastName = r.Employee.LastName,
                    Role = r.Role
                }).ToList()

            }).ToListAsync();

        var res = new NurseryBatchesDto
        {
            NurseryId = nursery.NurseryId,
            Name = nursery.Name,
            EstablishedDate = nursery.EstablishedDate,
            Batches = resBatches
        };
        
        return ServiceResult<NurseryBatchesDto>.SuccessResult(res);
        
    }
}
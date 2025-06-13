using LabAPBD_Test2.Models;
using Microsoft.EntityFrameworkCore;

namespace LabAPBD_Test2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Nursery> Nurseries { get; set; }
    public DbSet<SeedlingBatch> SeedlingBatches { get; set; }
    public DbSet<TreeSpecies> TreeSpecies { set; get; }
    public DbSet<Responsible> Responsibles { get; set; }
    public DbSet<Employee> Employees { get; set; }
    
    protected DatabaseContext()
    {
    }
    
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Nursery>().HasData(new List<Nursery>
        {
            new() { NurseryId = 1, EstablishedDate = new DateTime(2024, 01, 20), Name = "Some Nursery"},
            new() { NurseryId = 2, EstablishedDate = new DateTime(2024, 04, 10), Name = "Othre Nursery"},
        });

        modelBuilder.Entity<TreeSpecies>().HasData(new List<TreeSpecies>
        {
            new() { SpeciesId = 1, GrowthTimeInYears = 10, LatinName = "Some Species" },
            new() { SpeciesId = 2, GrowthTimeInYears = 20, LatinName = "Othre Species" }
        });

        modelBuilder.Entity<Employee>().HasData(new List<Employee>
        {
            new() { EmployeeId = 1, FirstName = "Mary", LastName = "Smith", HireDate = new DateTime(2005, 10, 17)},
            new() { EmployeeId = 2, FirstName = "John", LastName = "Dough", HireDate = new DateTime(2005, 10, 18)}
        });

        modelBuilder.Entity<SeedlingBatch>().HasData(new List<SeedlingBatch>
        {
            new()
            {
                BatchId = 1,
                NurseryId = 1,
                SpeciesId = 1,
                Quantity = 10,
                SownDate = new DateTime(2009, 10, 10),
                ReadyDate = null
            },
            new ()
            {
                BatchId = 2,
                NurseryId = 2,
                SpeciesId = 2,
                Quantity = 20,
                SownDate = new DateTime(2009, 10, 11),
                ReadyDate = new DateTime(2014, 10, 17)
            }
        });

        modelBuilder.Entity<Responsible>().HasData(new List<Responsible>
        {
            new()
            {
                BatchId = 1,
                EmployeeId = 1,
                Role = "ADMIN"
            },
            new()
            {
                BatchId = 2,
                EmployeeId = 2,
                Role = "MANAGER"
            }
        });

    }
    
}
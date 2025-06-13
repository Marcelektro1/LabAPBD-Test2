using Microsoft.EntityFrameworkCore;

namespace LabAPBD_Test2.Data;

public class DatabaseContext : DbContext
{
    // public DbSet<Medicament> Medicaments { get; set; }
    // public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    // public DbSet<Prescription> Prescriptions { set; get; }
    // public DbSet<Doctor> Doctors { get; set; }
    // public DbSet<Patient> Patients { get; set; }
    
    protected DatabaseContext()
    {
    }
    
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
        // {
        //     new() { IdDoctor = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@gmail.com" },
        //     new() { IdDoctor = 2, FirstName = "Steve", LastName = "Jobs", Email = "stevejobs@gmail.com" }
        // });
        //
        // modelBuilder.Entity<Patient>().HasData(new List<Patient>
        // {
        //     new() { IdPatient = 1, FirstName = "Alice", LastName = "Smith", Date = new DateTime(1990, 5, 20) },
        //     new() { IdPatient = 2, FirstName = "Bob", LastName = "Brown", Date = new DateTime(1985, 8, 15) }
        // });
        //
        // modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
        // {
        //     new() { IdMedicament = 1, Name = "Aspirin", Description = "Pain reliever", Type = "Tablet" },
        //     new() { IdMedicament = 2, Name = "Penicillin", Description = "Antibiotic", Type = "Injection" }
        // });
        //
        // modelBuilder.Entity<Prescription>().HasData(new List<Prescription>
        // {
        //     new() { IdPrescription = 1, Date = new DateTime(2024, 6, 1), DueDate = new DateTime(2024, 6, 15), IdPatient = 1, IdDoctor = 1 },
        //     new() { IdPrescription = 2, Date = new DateTime(2024, 6, 2), DueDate = new DateTime(2024, 6, 16), IdPatient = 2, IdDoctor = 2 }
        // });
        //
        // modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>
        // {
        //     new() { IdMedicament = 1, IdPrescription = 1, Dose = 2 },
        //     new() { IdMedicament = 2, IdPrescription = 1, Dose = 1 },
        //     new() { IdMedicament = 1, IdPrescription = 2, Dose = 1 }
        // });

    }
    
}
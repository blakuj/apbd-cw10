using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context;

public class ApplicationContext : DbContext
{
    
    protected ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients  { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions  { get; set; }
    public DbSet<Prescription_Medicament> PrescriptionMedicaments  { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { IdDoctor = 1, FirstName = "Jacek", LastName = "Kowalski", email = "jacek.kowalski@gmail.com" }
          
        );

        modelBuilder.Entity<Patient>().HasData(
            new Patient { IdPatient = 1, FirstName = "John", LastName = "Doe", BirthDate = new DateTime(1990, 1, 1) }
           
        );

        modelBuilder.Entity<Medicament>().HasData(
            new Medicament { IdMedicament = 1, Name = "Medicament1", Description = "Description1", Type = "Type1" }
           
        );

        modelBuilder.Entity<Prescription>().HasData(
            new Prescription
            {
                IdPrescription = 1,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                IdDoctor = 1, 
                IdPatient = 1 
            }
            
        );

        modelBuilder.Entity<Prescription_Medicament>().HasData(
            new Prescription_Medicament { IdPrescription = 1, IdMedicament = 1, Dose = 1, Details = "Details1" }
            
        );
    }

}
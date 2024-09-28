using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Data;

public class LabMosContext : DbContext
{
    public LabMosContext(DbContextOptions<LabMosContext> options)
        : base(options)
    {
    }

    public DbSet<Case> Cases { get; set; }

    public DbSet<Child> Children { get; set; }

    public DbSet<Contagion> Contagions { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<Direction> Directions { get; set; }

    public DbSet<DischargeHospitalized> DischargeHospitalizeds { get; set; }

    public DbSet<DischargeType> Dischargetypes { get; set; }

    public DbSet<Disease> Diseases { get; set; }

    public DbSet<DiseaseSymptom> Diseasesymptoms { get; set; }

    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Entities.File> Files { get; set; }

    public DbSet<Hospital> Hospitals { get; set; }

    public DbSet<Hospitalized> Hospitalizeds { get; set; }

    public DbSet<Laboratory> Laboratories { get; set; }

    public DbSet<Municipality> Municipalities { get; set; }

    public DbSet<Patient> Patients { get; set; }

    public DbSet<Pregnant> Pregnants { get; set; }

    public DbSet<Sample> Samples { get; set; }

    public DbSet<State> States { get; set; }

    public DbSet<Symptom> Symptoms { get; set; }

    public DbSet<Test> Tests { get; set; }

    public DbSet<Typehospital> Typehospitals { get; set; }

    public DbSet<User> Users { get; set; }
}

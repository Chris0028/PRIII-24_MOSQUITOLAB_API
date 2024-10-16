using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Dtos.Auth;
using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Entities;
using MosquitoLaboratorio.Dtos.File;

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

    public DbSet<Dischargehospitalized> Dischargehospitalizeds { get; set; }

    public DbSet<Disease> Diseases { get; set; }

    public DbSet<Diseasesymptomfile> Diseasesymptomfiles { get; set; }

    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Entities.File> Files { get; set; }

    public DbSet<Hospital> Hospitals { get; set; }

    public DbSet<Hospitalized> Hospitalizeds { get; set; }

    public DbSet<Insurance> Insurances { get; set; }

    public DbSet<InsurancePatient> InsurancePatients { get; set; }

    public DbSet<Laboratory> Laboratories { get; set; }

    public DbSet<Municipality> Municipalities { get; set; }

    public DbSet<Patient> Patients { get; set; }

    public DbSet<Pregnant> Pregnants { get; set; }

    public DbSet<Sample> Samples { get; set; }

    public DbSet<SampleManager> SampleManagers { get; set; }

    public DbSet<State> States { get; set; }

    public DbSet<Symptom> Symptoms { get; set; }

    public DbSet<Test> Tests { get; set; }

    public DbSet<User> Users { get; set; }

    #region Functions
    public DbSet<HistoryFileDTO> HistoryFileResults { get; set; }
    public DbSet<SampleDTO> UfcSampleList { get; set; }
    public DbSet<AuthUserDTO> UfcUserAuth { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CreateFileDTO>().HasNoKey();
        modelBuilder.Entity<HistoryFileDTO>().HasNoKey();
        modelBuilder.Entity<SampleDTO>().HasNoKey();
        modelBuilder.Entity<AuthUserDTO>().HasNoKey();
        base.OnModelCreating(modelBuilder);   
    }
}

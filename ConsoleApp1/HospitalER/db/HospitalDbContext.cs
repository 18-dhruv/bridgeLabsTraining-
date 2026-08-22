using Microsoft.EntityFrameworkCore;

namespace HospitalER;

public class HospitalDbContext:DbContext
{
    public DbSet<Nurse>Nurses;
    public DbSet<Doctor> Doctors;
    public DbSet<Patient> Patients;

    protected override void OnConfiguring(DbContextOptionsBuilder option)
    {
        option.UseNpgsql("Host=localhost,Port=5432,Database=hospital-postgres,Username=postgres,password=password");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Staff>()
            .HasDiscriminator<string>("StaffType")
            .HasValue<Doctor>("Doctor")
            .HasValue<Nurse>("Nurse");
    }
}
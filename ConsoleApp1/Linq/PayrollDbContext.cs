using Microsoft.EntityFrameworkCore;

namespace Linq;

public class PayrollDbContext:DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
    public DbSet<Contractor> Contractors { get; set; }
    public DbSet<AttendanceRecord> AttendanceRecords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
     optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=payrolldb;Username=postgres;Password=password");
    }
}
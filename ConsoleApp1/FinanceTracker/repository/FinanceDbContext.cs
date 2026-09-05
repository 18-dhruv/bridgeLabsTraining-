using FinanceTracker;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker;

public class FinanceDbContext:DbContext
{
   public DbSet<Transaction> Transactions { get; set; }

   protected override void OnConfiguring(DbContextOptionsBuilder option)
   {
      option.UseNpgsql("Host=localhost;Port=5432;Database=FinanceDb;Username=postgres;Password=password");
   }
}
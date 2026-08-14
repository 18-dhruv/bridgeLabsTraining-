using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Logging;

namespace Linq;

public class Program
{
    public static void Main(String[] args)
    {
        using (var dbContext = new PayrollDbContext())
        {
            //     FullTimeEmployee rahul, priya, karan;
            //     Contractor neha, aman, zara;
            //
            //     if (!dbContext.Employees.Any())
            //     {
            //         rahul = new FullTimeEmployee("Rahul", 45000, "Engineering", 5000);
            //         priya = new FullTimeEmployee("Priya", 52000, "Sales", 3000);
            //         karan = new FullTimeEmployee("Karan", 48000, "Engineering", 4000);
            //         neha  = new Contractor("Neha", "Design", 800, 120);
            //         aman  = new Contractor("Aman", "Design", 750, 100);
            //         zara  = new Contractor("Zara", "Marketing", 900, 80);
            //
            //         dbContext.Employees.AddRange(rahul, priya, karan, neha, aman, zara);
            //         dbContext.SaveChanges();
            //     }
            //     else
            //     {
            //         // employees already exist — fetch them back from the DB by name
            //         rahul = dbContext.Employees.OfType<FullTimeEmployee>().First(e => e.Name == "Rahul");
            //         priya = dbContext.Employees.OfType<FullTimeEmployee>().First(e => e.Name == "Priya");
            //         karan = dbContext.Employees.OfType<FullTimeEmployee>().First(e => e.Name == "Karan");
            //         neha  = dbContext.Employees.OfType<Contractor>().First(e => e.Name == "Neha");
            //         aman  = dbContext.Employees.OfType<Contractor>().First(e => e.Name == "Aman");
            //         zara  = dbContext.Employees.OfType<Contractor>().First(e => e.Name == "Zara");
            //     }
            //
            //     if (!dbContext.AttendanceRecords.Any())
            //     {
            //         var records = new List<AttendanceRecord>
            //         {
            //             new AttendanceRecord(rahul.Id, DateTime.UtcNow.Date.AddDays(-2), AttendanceStatus.Present),
            //             new AttendanceRecord(rahul.Id, DateTime.UtcNow.Date.AddDays(-1), AttendanceStatus.Absent),
            //             new AttendanceRecord(neha.Id, DateTime.UtcNow.Date.AddDays(-2), AttendanceStatus.Present),
            //             // add more across other employees/days
            //         };
            //
            //         dbContext.AttendanceRecords.AddRange(records);
            //         dbContext.SaveChanges();
            //     }


            // var TotalPayrole = dbContext.Employees.ToList().Sum(x => x.CalculateNetPay());
            // 
            // Decimal threshold = 10000;
            // var allFullTimeEmployees = dbContext.Employees.OfType<FullTimeEmployee>()
            //     .Where(e => e.BaseSalary > threshold)
            //     .OrderByDescending(e => e.BaseSalary + e.Bonus)
            //     .ToList();
            //
            //
            // foreach (var f in allFullTimeEmployees)
            // {
            //     Console.WriteLine($"{f.Name}   {f.BaseSalary+f.Bonus}");
            // }
           // Get all Contractors, sorted by net pay (HourRate * Hour) descending.
           // var AllContractors = dbContext.Employees.OfType<Contractor>().OrderByDescending(e => e.Hour * e.HourRate);
           // foreach (var c in  AllContractors)
           // {
           //     Console.WriteLine(c.Name+$"   {c.Hour*c.HourRate}");
           // }
           //Find the single highest-paid employee overall — across both FullTimeEmployees and Contractors — return just their name.
          
           //Console.WriteLine(maxpay);
           // var HighestPaidFulltime = dbContext.Employees.OfType<FullTimeEmployee>().OrderByDescending(e => e.BaseSalary * e.Bonus).FirstOrDefault();
           // Console.WriteLine(HighestPaidFulltime.Name);
           var absentee = dbContext.Employees(EId ,id=>Employee.Id,EId=>AttendanceRecord.ID,)
           
        }

        

    }

}
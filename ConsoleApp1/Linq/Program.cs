using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
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
            // var absent = dbContext.Employees.Join(dbContext.AttendanceRecords,
            //         e => e.Id,
            //         a => a.EmployeeId,
            //         (employee, record) => new { Employee = employee, AttendanceRecord = record }
            //     ).Where(x => x.AttendanceRecord.Status == AttendanceStatus.Absent)
            //     .Select(x => x.Employee.Name)
            //     .Distinct()
            //     .ToList();
            // foreach (string s in absent)
            // {
            //     Console.WriteLine(s);
            // }
            //
            //
            // var noOfEmployee = dbContext.Employees
            //     .GroupBy(x => x.Department)
            //     .Select(x => new { Department = x.Key, Count = x.Count() })
            //     .OrderByDescending(x => x.Count);
            // foreach (var v in noOfEmployee)
            // {
            //     Console.WriteLine($"{v.Department}   {v.Count}");
            // }
            //
            //    var AvgFullTime = dbContext.Employees.OfType<FullTimeEmployee>()
            //        .Average(x => x.BaseSalary + x.Bonus);
            //   
            //    var avgContract = dbContext.Employees.OfType<Contractor>()
            //        .Average(x => x.Hour * x.HourRate);
            //    if (avgContract > AvgFullTime)
            //    {
            //        Console.WriteLine(avgContract);
            //        Console.WriteLine("contract");
            //    }
            //    else
            //    {
            //        Console.WriteLine(AvgFullTime);
            //        Console.WriteLine("full time");
            //    }
            // }

            // var RahulAttendance = dbContext.Employees
            //     .Join(dbContext.AttendanceRecords,
            //         e => e.Id,
            //         a => a.EmployeeId,
            //         (employee, record) => new { Employee = employee, AttendanceRecord = record })
            //     .Where(x => x.Employee.Name == "Rahul" )
            //     .OrderBy(x=>x.AttendanceRecord.Date)
            //     .Select(x => new
            //     {
            //         x.Employee,
            //         x.AttendanceRecord.Status,
            //         x.AttendanceRecord.Date
            //     });
                
            // foreach (var c in  RahulAttendance)
            // {
            //       Console.WriteLine($"{c.Date}  {c.Status}");
            // }
            // var salaryPerDepartment = dbContext.Employees
            //     .GroupBy(x => x.Department)
            //     .ToList()
            //     .Select(x => new
            //     {
            //         Department = x.Key, 
            //         pay = x.Sum(p=>p.CalculateNetPay()),
            //         headCount =x.Count()
            //     });
            // foreach (var v in salaryPerDepartment)
            // {
            //     Console.WriteLine($" {v.Department}   {v.pay}    {v.headCount}");
            // }
           //Find the employee (across both subtypes) with the lowest net pay overall. Return their name and their net pay
           // var LowestPaidInFullTime = dbContext.Employees.OfType<FullTimeEmployee>()
           //     .Select(x => new { FullTimeEmployee = x, Salary = x.BaseSalary + x.Bonus })
           //     .OrderBy(x => x.Salary)
           //     .First();
           // var LowestPaidContract = dbContext.Employees.OfType<Contractor>()
           //     .Select(x => new
           //     {
           //         Contractor = x,
           //         Salary = x.Hour * x.HourRate
           //     })
           //     .OrderBy(x => x.Salary)
           //     .First();
           // if (LowestPaidContract.Salary < LowestPaidInFullTime.Salary)
           // {
           //     Console.WriteLine($"{LowestPaidContract.Contractor.Name}    {LowestPaidContract.Salary}");
           // }
           // else
           // {
           //     Console.WriteLine($"{LowestPaidInFullTime.FullTimeEmployee.Name}    {LowestPaidInFullTime.Salary}");
           // }

           // var LowestPaid = dbContext.Employees
           //     .ToList()
           //     .OrderBy(x=>x.CalculateNetPay())
           //     .First();
           // Console.WriteLine($"{LowestPaid.Name}   {LowestPaid.CalculateNetPay()}");
           
          // Get a list of all distinct department names that have at least one FullTimeEmployee in them (not Contractors).
          var ListDpFullTime = dbContext.Employees.OfType<FullTimeEmployee>()
              .Select(x => x.Department)
              .Distinct()
              .ToList();
          foreach (var c in ListDpFullTime)
          {
              Console.WriteLine($"{c}");
          }

        }
    }
}


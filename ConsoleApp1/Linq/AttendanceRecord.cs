using System;
namespace Linq;

public class AttendanceRecord
{
   public int Id { get; private set; }
   public int EmployeeId { get; private set; }
   public DateTime Date { get; private set; }
   public AttendanceStatus Status { get; private set; }

   public AttendanceRecord(int employeeId, DateTime date, AttendanceStatus status)
   {
      this.EmployeeId = employeeId;
      this.Date = date;
      this.Status = status;
   }
    
}

public enum AttendanceStatus
{
   Present,
   Absent,
   HalfDay,
   Leave
}
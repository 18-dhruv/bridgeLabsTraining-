namespace Linq;

public class AttendanceService
{
    public void MarkAttendance(List<AttendanceRecord> records, int EmployeeId,DateTime date ,AttendanceStatus status)
    {
        var Existing = records.FirstOrDefault(r => r.EmployeeId == EmployeeId && r.Date == DateTime.Today);
        if(Existing!=null)
        {
            throw new InvalidAttendance($"the attendance for this {EmployeeId} has been marked for {DateTime.Today}");
        }
        else
        {
            AttendanceRecord attendanceRecord = new AttendanceRecord(EmployeeId,date, status);
            records.Add(attendanceRecord);
        }
    }
}
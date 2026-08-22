using System.Runtime.InteropServices.JavaScript;

namespace HospitalER;

public abstract class Staff :Person,IEntity<int>
{
    public int Id { get; }
    public string Department {get;}
    public DateTime Shift { get; }
    public Staff(string name, string phoneNumber, string address, string age,string department,DateTime shift) : base(name, phoneNumber, address, age)
    {
        this.Department = department;
        this.Shift = shift;
    }
}
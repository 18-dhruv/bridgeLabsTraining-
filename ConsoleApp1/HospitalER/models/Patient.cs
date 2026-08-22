namespace HospitalER;

public class Patient:Person,IComparable<Patient>,IEntity<int>
{
    public int Id { get;}
    public string Name {get;}
    public string PhoneNumber { get; }
    public string Address { get; }
    public string Severity { get; }
    public string Age { get;}

    public Patient(string name,string phoneNumber ,string address,string severity,string age) : base(name,phoneNumber, address, age)
    {
        this.Severity = severity;
    }

    public int CompareTo(Patient a )
    {
        if (a == null) return 1;
        return this.Severity.CompareTo(a.Severity);
    }
    
}
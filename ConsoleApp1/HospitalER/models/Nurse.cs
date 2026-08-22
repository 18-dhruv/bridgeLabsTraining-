namespace HospitalER;

public class Nurse:Staff
{
    public int WardNumber { get; set; }

    public Nurse(string name, string phoneNumber, string address, string age, string department, DateTime shift,
        int wardNumber) : base(name, phoneNumber, address, age, department, shift)
    {
        this.WardNumber = WardNumber;
    }
}
namespace HospitalER;

public class Doctor:Staff
{
    public string Speciality { get; }

    public Doctor(string name, string phoneNumber, string address, string age, string department, DateTime shift,
        string speciality) : base(name, phoneNumber, address, age, department, shift)
    {
        this.Speciality = speciality;
    }
}
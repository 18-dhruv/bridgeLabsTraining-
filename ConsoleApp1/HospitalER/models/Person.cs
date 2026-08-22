namespace HospitalER;

public abstract class Person{
public string Name {get;}
public string PhoneNumber { get; }
public string Address { get; }
public string Age { get; }
public Person(string name,string phoneNumber ,string address,string age){
    this.Address = address;
    this.Age = age;
    this.Name = name;
    this.PhoneNumber = phoneNumber;
}

}
namespace Linq;

public abstract class Employee:IPayable
{
    public int Id { get; private set; }
    public  string Name { get; private set; }
    public Decimal BaseSalary { get; set;}
    public string Department { get; set; }
    

   public Employee(string Name,Decimal BaseSalary,string Department)
   {
       
       this.Name = Name;
       this.BaseSalary = BaseSalary;
       this.Department = Department;
   }

   public abstract Decimal CalculateNetPay();

   public virtual string GetSummary()
   {
       return $"{this.Id} {this.Name}   {this.BaseSalary}";
   }
}
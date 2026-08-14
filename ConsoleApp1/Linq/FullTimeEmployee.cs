namespace Linq;

public class FullTimeEmployee:Employee
{
  public Decimal Bonus { get; set;}

  public FullTimeEmployee(string Name, Decimal BaseSalary, string Department, Decimal Bonus) : base(Name, BaseSalary,
    Department)
  {
    this.Bonus = Bonus; 
  }

  public override decimal CalculateNetPay()
  {
    return this.BaseSalary + this.Bonus;
  }

  public override string GetSummary()
  {
    return base.GetSummary()+$" bonus : {this.Bonus}";
  }
  
}
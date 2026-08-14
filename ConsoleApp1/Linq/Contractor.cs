namespace Linq;

public class Contractor:Employee
{
    public Decimal HourRate { get; private set; }
    public int Hour { get; private set; }
    public Contractor(string Name, string Department, Decimal HourRate,int Hour) : base(Name, 0, Department)
    {
        this.Hour = Hour;
        this.HourRate = HourRate;
    }

    public override decimal CalculateNetPay()
    {
        return this.Hour * this.HourRate;
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" hour : {Hour}  hour rate : {HourRate}  pay : {CalculateNetPay()}";
    }
}
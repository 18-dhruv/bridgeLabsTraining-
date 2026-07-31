namespace bank;

public class IntrestEarningAccount: BankAccount
{
    public IntrestEarningAccount(String Name, double Deposit) : base(Name, Deposit){}

    public override void PerformEndMonthTransaction()
    {
        if (balance > 500)
        {
            MakeDeposit(balance / 100 * 2);
        }
    }
}
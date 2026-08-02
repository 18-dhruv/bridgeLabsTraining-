namespace bank;

public class IntrestEarningAccount: BankAccount
{
    public IntrestEarningAccount(String Name, double Deposit) : base(Name, Deposit){}

    public override void PerformEndMonthTransaction()
    {
        if (Balance > 500)
        {
            MakeDeposit(Balance / 100 * 2);
        }
    }
}
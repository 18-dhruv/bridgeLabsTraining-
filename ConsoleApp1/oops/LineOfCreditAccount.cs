namespace bank;

public class LineOfCreditAccount: BankAccount
{
    public LineOfCreditAccount(string Name , double InitialDeposit): base(Name, InitialDeposit){}
    public override void PerformEndMonthTransaction()
    {
        if (balance <= 0)
        {
            balance -= balance / 100 * 7;
        }
    }
}
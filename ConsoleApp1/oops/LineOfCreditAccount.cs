namespace bank;

public class LineOfCreditAccount: BankAccount
{
    public LineOfCreditAccount(string Name , double InitialDeposit,double CreditLimit): base(Name, InitialDeposit,-CreditLimit){}
    public override void PerformEndMonthTransaction()
    {
        if (Balance < 0)
        {
            Double withdraw = Balance / 100 * 7;
            MakeWithdrawal(-withdraw);
        }
    }
}
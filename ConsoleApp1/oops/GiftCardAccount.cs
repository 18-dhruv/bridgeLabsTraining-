namespace bank;

public class GiftCardAccount:BankAccount
{
    private readonly double _monthlyDeposit=0;

    public GiftCardAccount(string name, double InitialDeposit,double monthlyDeposit=0) : base(name, InitialDeposit)
    =>_monthlyDeposit=monthlyDeposit;

    public override void PerformEndMonthTransaction()
    {
        if (_monthlyDeposit != 0)
        {
            MakeDeposit(_monthlyDeposit);
        }
    }
}




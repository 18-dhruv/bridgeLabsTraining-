namespace bank;

public class BankAccount
{
    private string Owner { get; set; }
    protected  double Balance { get; set; }

    protected readonly double MinimumBal;
    private List<Transaction> Transactions { get; set; }
    public BankAccount(string name, double initialDeposit) : this(name, initialDeposit, 0) { }

    public BankAccount(string name, double initialDeposit,double minimumBal)
    {
        this.Owner = name;
        this.Balance = 0;
        this.Transactions = new List<Transaction>();
        this.MinimumBal = minimumBal;
        MakeDeposit(initialDeposit);
    }
    //MakeDeposit
    internal double MakeDeposit(double depositAmmount)
    {
        Balance += depositAmmount;
        Transaction t = new Transaction(Balance);
        Transactions.Add(t);
        return Balance;
    }
    //MakeWithdrawal
    internal double MakeWithdrawal(double withdrawalAmmount)
    {   
        if (Balance-withdrawalAmmount<MinimumBal)
        {
            throw new InsufiecientBalance("balance is insuffiecient "+ Balance);
        }
        Balance -= withdrawalAmmount;
        Transaction t = new Transaction(Balance);
        Transactions.Add(t);
        return Balance;
    }

    internal List<Transaction> GetAccountHistory()
    {
        if (Transactions.Count == 0) throw new NoTransaction("no transaction");
        return Transactions;
    }
    public virtual void PerformEndMonthTransaction(){}
}


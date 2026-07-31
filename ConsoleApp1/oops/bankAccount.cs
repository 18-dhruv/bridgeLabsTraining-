namespace bank;

public class BankAccount
{
    private string owner { get; set; }
    private  double balance { get; set; }
    private List<Transaction> transactions { get; set; }
    public BankAccount(string name, double initialDeposit)
    {
        this.owner = name;
        this.balance = 0;
        this.transactions = new List<Transaction>();
        MakeDeposit(initialDeposit);
    }
    //MakeDeposit
    internal double MakeDeposit(double DepositAmmount)
    {
        balance += DepositAmmount;
        Transaction t = new Transaction(balance);
        transactions.Add(t);
        return balance;
    }
    //MakeWithdrawal
    internal double MakeWithdrawal(double WithdrawalAmmount)
    {
        if (WithdrawalAmmount > balance)
        {
            throw new InsufiecientBalance("balance is insuffiecient "+ balance);
        }
        Transaction t = new Transaction(balance);
        transactions.Add(t);
        balance -= WithdrawalAmmount;
        return balance;
    }

    internal List<Transaction> GetAccountHistory()
    {
        if (transactions.Count == 0) throw new NoTransaction("no transaction");
        return transactions;
    }
    
}


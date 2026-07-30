namespace practiceException;

public class Atm
{
    public long balance = 0;
    public string user ;

    public Atm(long balance,string user)
    {
        this.balance = balance;
        this.user = user;
    }

    public long withdraw(long money)
    {
            if (balance < money)
            {
                throw new InsuffiecientBalance("balance is insuffiecient "+ balance);
            }

            balance = balance - money;
            return balance ;
    }
}
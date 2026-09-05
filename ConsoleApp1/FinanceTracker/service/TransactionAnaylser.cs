using FinanceTracker;

namespace FinanceTracker;


public class TransactionAnaylser
{
    private readonly IRepository<int, Transaction> repo;

    public TransactionAnaylser(IRepository<int, Transaction> repo)
    {
        this.repo = repo;
    }

    public Decimal TotalSpend()
    {
        return repo.GetAll().Sum(x => x.Value.Amount);
    }
    public KeyValuePair<Category, Decimal> GetLargestExpense()
    {
        var t = repo.GetAll().ToDictionary().Values.MaxBy(x=>x.Amount);
        return new KeyValuePair<Category, decimal>(t.Category, t.Amount);
    }
    
    public IEnumerable<KeyValuePair<Category, Decimal>> GetSpendByCategory()
    {
        var t   = repo.GetAll()
            .GroupBy(x => x.Value.Category)
            .Select(x => new KeyValuePair<Category, Decimal>(x.Key, x.Sum(e => e.Value.Amount)));
        return t;
    }
    
        

}

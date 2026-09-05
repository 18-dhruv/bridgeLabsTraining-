using System.Diagnostics;
using FinanceTracker;
public class Program
{
    public static void Main(string[] args)
    {
        using (var dbContext = new FinanceDbContext())
        {
            // Transaction t1 = new Transaction("house rent", 124434, Category.BillPayment, DateTime.UtcNow);
            // Transaction t2 = new Transaction("electricity bill", 4500, Category.BillPayment, DateTime.UtcNow);
            // Transaction t3 = new Transaction("internet bill", 1499, Category.BillPayment, DateTime.UtcNow);
            // Transaction t4 = new Transaction("grocery shopping", 7850, Category.Groceries, DateTime.UtcNow);
            // Transaction t5 = new Transaction("vegetables", 1200, Category.Groceries, DateTime.UtcNow);
            // Transaction t6 = new Transaction("restaurant dinner", 3200, Category.Food, DateTime.UtcNow);
            // Transaction t7 = new Transaction("coffee", 350, Category.Food, DateTime.UtcNow);
            // Transaction t8 = new Transaction("new shoes", 4500, Category.Shopping, DateTime.UtcNow);
            // Transaction t9 = new Transaction("new shirt", 2800, Category.Shopping, DateTime.UtcNow);
            // Transaction t10 = new Transaction("petrol", 3000, Category.Fuel, DateTime.UtcNow);
            // Transaction t11 = new Transaction("diesel", 2500, Category.Fuel, DateTime.UtcNow);
            // Transaction t12 = new Transaction("salary", 95000, Category.MoneyRecived, DateTime.UtcNow);
            // Transaction t13 = new Transaction("freelance payment", 25000, Category.MoneyRecived, DateTime.UtcNow);
            // Transaction t14 = new Transaction("sent to friend", 5000, Category.MoneyTransfer, DateTime.UtcNow);
            // Transaction t15 = new Transaction("bank transfer", 10000, Category.MoneyTransfer, DateTime.UtcNow);
            // Transaction t16 = new Transaction("movie tickets", 1200, Category.Miscellaneous, DateTime.UtcNow);
            // Transaction t17 = new Transaction("mobile recharge", 799, Category.BillPayment, DateTime.UtcNow);
            // Transaction t18 = new Transaction("medical supplies", 1800, Category.Miscellaneous, DateTime.UtcNow);
            // Transaction t19 = new Transaction("online shopping", 6500, Category.Shopping, DateTime.UtcNow);
            // Transaction t20 = new Transaction("lunch", 850, Category.Food, DateTime.UtcNow);
            // dbContext.Transactions.AddRange(t1, t2 , t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20);
            // dbContext.SaveChanges();
            IRepository<int, Transaction> repo = new Repository<int, Transaction>(dbContext);
            TransactionFilter tf = new TransactionFilter(repo);
            // Predicate<Transaction> check = x => x.Amount>5000;
            // var t =tf.FilterByCondition(check);
            // foreach (var tr in t)
            // {
            //     Console.WriteLine(tr);
            // }
            
            TransactionAnaylser ta = new TransactionAnaylser(repo);
            // Console.Write(ta.TotalSpend());
            // var a =ta.GetSpendByCategory();
            // foreach (var b in a)
            // {
            //     Console.WriteLine($"{b.Key}   {b.Value}");
            // }
            
        }
        
    }
}
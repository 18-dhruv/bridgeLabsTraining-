using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace FinanceTracker;

public class Transaction : IEntity<int> 
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public Category Category { get; set; }
    public DateTime DateTime { get; set; }

    public Transaction(string description, Decimal amount, Category category, DateTime dateTime)
    {
        this.Description = description;
        this.Category = category;
        this.Amount = amount;
        this.DateTime = dateTime;
    }
}

public enum Category
{
    Food,
    MoneyRecived,
    Groceries,
    MoneyTransfer,
    Shopping,
    Fuel,
    BillPayment,
    Miscellaneous
}
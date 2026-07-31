using System;
namespace bank;

public class Transaction
{
  private string DateTimeAt;
  private double balanceAtThatTime;

  public Transaction(double balance)
  {
    DateTime Date_Time = DateTime.Now;
    this.DateTimeAt = Date_Time.ToString("g");
    this.balanceAtThatTime = balance;
  }

  internal string TransactionToString()
  {
    return DateTimeAt +"  "+balanceAtThatTime;
  }
}
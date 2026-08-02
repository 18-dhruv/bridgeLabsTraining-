using System;

//A base BankAccount class with Owner, Balance, MakeDeposit(), MakeWithdrawal(), GetAccountHistory().
namespace bank
{
   public class Program
   {
      public static void Main(string[] args)
      {
        //  BankAccount bk = new BankAccount("herer", 180247);
        // try
        // {
        //    Console.WriteLine(bk.MakeDeposit(1000));
        // }
        // catch (Exception e)
        // {
        //    throw new ApplicationException("hello from error", e);
        // }
        //
        //  foreach(Transaction t in bk.GetAccountHistory())
        // {
        //    Console.WriteLine(t.TransactionToString());
        // }
        // var savings = new IntrestEarningAccount("Savings", 500);
        // savings.PerformEndMonthTransaction();
        //
        // foreach (var t in savings.GetAccountHistory())
        //    Console.WriteLine(t.TransactionToString());
        // BankAccount account = new IntrestEarningAccount("Test", 10000);   // note: declared as BankAccount, not InterestEarningAccount
        // account.PerformEndMonthTransaction();
        //
        // foreach (var t in account.GetAccountHistory())
        //    Console.WriteLine(t.TransactionToString());
        // 
        // var lineOfCredit = new LineOfCreditAccount("Credit Test", 0, 2000);
        // lineOfCredit.MakeWithdrawal(1000);
        // lineOfCredit.PerformEndMonthTransaction();
        //
        // foreach (var t in lineOfCredit.GetAccountHistory())
        //     Console.WriteLine(t.TransactionToString());
        // var giftCardNoDeposit = new GiftCardAccount("NoDeposit", 100);   // omitting monthlyDeposit entirely
        // giftCardNoDeposit.PerformEndMonthTransaction();
        //
        // foreach (var t in giftCardNoDeposit.GetAccountHistory())
        //    Console.WriteLine(t.TransactionToString());
        // var giftCard = new GiftCardAccount("Gift", 100, 50);
        // giftCard.MakeWithdrawal(20);
        // giftCard.PerformEndMonthTransaction();
        //
        // foreach (var t in giftCard.GetAccountHistory())
        //    Console.WriteLine(t.TransactionToString());
        //
      }
   }

}
using System;

//A base BankAccount class with Owner, Balance, MakeDeposit(), MakeWithdrawal(), GetAccountHistory().
namespace bank
{
   public class Program
   {
      public static void Main(string[] args)
      {
         BankAccount bk = new BankAccount("herer", 180247);
         try
         {
            Console.WriteLine(bk.MakeDeposit(1000));
         }
         catch (Exception e)
         {
            throw new ApplicationException("hello from error", e);
         }

         foreach(Transaction t in bk.GetAccountHistory())
        {
           Console.WriteLine(t.TransactionToString());
        }
      }
   }

}
using System;
//You are writing the software for an ATM. You need to handle the situation where a user tries to withdraw more money than they have, and you need to pass that error up to the main system safely.
// 
// Your goal is to write three things:
// 
// 1. The Custom Exception
// Create a new exception called InsufficientFundsException.
// 
// It must inherit from the modern base Exception class.
// 
// Give it a constructor that takes a string message and passes it to the base constructor.
// 
// 2. The Wrapper Exception
// Create a second exception called AtmSystemException.
// 
// This one needs a constructor that takes both a string message AND an Exception inner, passing both to the base constructor.
// 
// 3. The Logic (The Throw and the Wrap)
// Write a simple class with two methods to simulate the process:
// 
// Method A (ProcessWithdrawal): Pretend the user has a balance of $50, but tries to withdraw $100. Write the code that directly throws your new InsufficientFundsException.
// 
// Method B (Main or RunAtm): Call Method A inside a try block. In the catch block, catch the InsufficientFundsException, and then throw your AtmSystemException, passing in a high-level message (like "Transaction failed") and the original exception as the inner exception.

namespace practiceException
{
   
    

    public class example
    {
        public static void Main()
        {
            Atm w = new Atm(50, "hello");
            Atm d = new Atm(100, "hi");
            try
            {
                w.withdraw(200);

            }
            catch (InsuffiecientBalance e)
            {
                throw new ApplicationException("error", e);
            }
            finally
            {
                Console.WriteLine("done ");
            }
        }
    }
}
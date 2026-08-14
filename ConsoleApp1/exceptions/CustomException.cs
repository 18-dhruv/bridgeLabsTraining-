using System;


namespace practiceException
{
    internal class ApplicationException : Exception
    {

       internal  ApplicationException(string message) : base(message)
        {
        }

        internal ApplicationException(string message, Exception inner) : base(message, inner)
        {
        }
    }

  internal class InsuffiecientBalance : Exception
    {
       
      internal InsuffiecientBalance(string message) : base(message) {}
    }
}
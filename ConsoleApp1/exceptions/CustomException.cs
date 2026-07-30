using System;


namespace practiceException
{
    public class ApplicationException : Exception
    {

        public ApplicationException(string message) : base(message)
        {
        }

        public ApplicationException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    public class InsuffiecientBalance : Exception
    {
        public InsuffiecientBalance(string message) : base(message)
        {
        }
        
    }
}
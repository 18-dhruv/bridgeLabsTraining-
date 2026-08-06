namespace LibraryCheckout;

public class BorrowLimitExceeded:Exception
{
    public BorrowLimitExceeded(string message):base(message){}
}

public class NotBorrowed : Exception
{
    public NotBorrowed(String message):base(message){}
}

public class BookDoesntExist : Exception
{
   public BookDoesntExist (String message):base(message){}
}
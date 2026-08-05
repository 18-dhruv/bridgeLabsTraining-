namespace LibraryCheckout;

public class BorrowLimitExceeded:Exception
{
    public BorrowLimitExceeded(string message){}
}

public class NotBorrowed : Exception
{
    public NotBorrowed(String message){}
}

public class BookDoesntExist : Exception
{
   public BookDoesntExist (String message){}
}
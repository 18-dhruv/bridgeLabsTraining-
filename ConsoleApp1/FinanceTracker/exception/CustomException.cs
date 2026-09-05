using FinanceTracker;

public class CustomException : Exception
{
    public CustomException(String message, Exception inner) : base(message, inner)
    {
    }
}


public class EntityDontExist : Exception
{
    public EntityDontExist(String message) : base(message)
    {
    }
}

public class EntityAlreadyExist : Exception
{
    public EntityAlreadyExist(String message) : base(message)
    {
    }
}


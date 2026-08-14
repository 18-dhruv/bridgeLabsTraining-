namespace Linq;

public class CustomException:Exception
{
    public CustomException(string message,Exception inner) : base(message, inner){}
}

public class InvalidAttendance : Exception
{
   public InvalidAttendance(string message):base(message){}
}
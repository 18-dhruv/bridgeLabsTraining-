using System.ComponentModel.DataAnnotations;

namespace HospitalER.exception;

public class CustomException : Exception
{
    public CustomException(string message,Exception inner):base(message, inner){}
    public CustomException(string message) : base(message){}
}

public class EntityDontExist:Exception
{
    public EntityDontExist(string message):base(message){}
}

public class NoPatientInQueue : Exception
{
    public NoPatientInQueue(string message):base(message){}
}
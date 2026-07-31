using System.ComponentModel.DataAnnotations;

namespace bank;

public class InsufiecientBalance: Exception
{
    public InsufiecientBalance(string message) :base(message){}
}

public class NoTransaction : Exception
{
    public NoTransaction(string message):base(message){}
}
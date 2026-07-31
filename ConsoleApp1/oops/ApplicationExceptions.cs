namespace bank;

public partial class ApplicationExceptions : Exception

{
   internal ApplicationExceptions(string message) : base(message){}
   internal ApplicationExceptions(string message,ApplicationException inner) :base(message,inner){}
   
}
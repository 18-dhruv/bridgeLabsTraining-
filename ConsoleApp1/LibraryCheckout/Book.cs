namespace LibraryCheckout;

public class Book
{
    public string bookName { get; }
    public string author { get; }
    public string ISBN { get; }
    public Status status { get; set; }
    public int Copies { get;} 
    internal Book(string name, string author,int copies)
    {
        this.Copies = copies;
        this.bookName = name;
        this.author = author;
    }
    
}

public enum Status
{
    borrowed,
    unborrowed
}
namespace LibraryCheckout;

public class Book
{
    public string bookName { get; }
    public string author { get; }
    public string ISBN { get; }
    public Status status { get; set; }
    protected internal Book(string name, string author)
    {
        this.bookName = name;
        this.author = author;
    }

    public override bool Equals(object? o)
    {
        if (!(o is Book))
        {
            return false;
        }

        Book b = (Book)o;
        return author == b.author && bookName == b.bookName;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(author, bookName);
    }
}

public enum Status
{
    borrowed,
    unborrowed
}
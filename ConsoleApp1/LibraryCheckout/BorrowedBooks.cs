namespace LibraryCheckout;

public class BorrowedBooks
{
    public Members member;
    public Book book;

    protected internal BorrowedBooks(Members member, Book book)
    {
        this.book = book;
        this.member = member;
    }

    public string returnName(BorrowedBooks book)
    {
        return $"book : {book.book.bookName}   issued by : {book.member.Name}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is not BorrowedBooks b)
        {
            return false;
        }

        return book.Equals(b.book) && member.Equals(b.member);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(book.bookName, member.Name);
    }
}
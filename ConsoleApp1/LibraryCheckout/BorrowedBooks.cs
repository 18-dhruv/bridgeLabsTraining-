namespace LibraryCheckout.obj;

public class BorrowedBooks
{
    public Members member;
    public Book book;

    protected BorrowedBooks(Members member, Book book)
    {
        this.book = book;
        this.member = member;
    }
    public void returnName()
}
namespace LibraryCheckout;

public class Members
{
    public string Name { get; }
    public static int membersCounter { get; set; }
    public string MemberId { get; }
    public List<Book>BooksCheckout { get; }

   public Members(string name)
    {
        this.Name = name;
        this.MemberId = (membersCounter++).ToString();
        BooksCheckout = new List<Book>();
    }

    public void borrowBook(Book book)
    {
        if (BooksCheckout.Count >= 3)
        {
            throw new BorrowLimitExceeded("u can't borrow more than three books");
        }
        
       BooksCheckout.Add(book);
    }

    public void ReturnBook(Book book)
    {
        if (BooksCheckout.Contains(book))
        {
            BooksCheckout.Remove(book);
        }
        else
        {
            throw new NotBorrowed("book not issued to u");
        }
    }   
    
}
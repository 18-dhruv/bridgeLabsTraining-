namespace LibraryCheckout;

public class Library
{
    public static Dictionary<Book, List<List<Members>>> library = new Dictionary<Book, List<List<Members>>>();

    public void CreateBook(string name, string author, int copies)
    {
        Book b = new Book(name, author, copies);
        library.Add(b, new List<List<Members>>());
    }
    
    public void BorrowBook(Members member,Book book)
    {
        if (member.BooksCheckout.Count >= 3)
        {
            throw new BorrowLimitExceeded("u can't borrow more than three books");
        }
        else
        {
            if (library.ContainsKey(book))
            {
                List<Members> list = new List<Members>(); 
                
            }
            else
            {
                throw new BookDoesntExist("no book found");
            }
        }
        
    }
}
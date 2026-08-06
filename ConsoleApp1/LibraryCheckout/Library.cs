using System.ComponentModel;


namespace LibraryCheckout;

public class Library
{
    private static List<BorrowedBooks> BooksBorrowed = new List<BorrowedBooks>();
    private Dictionary<Book, int> library = new Dictionary<Book, int>();
    
    
    public Book CreateBook(string name, string author)
    {
        Book b = new Book(name, author);
        if (library.ContainsKey(b))
        {
            library[b]=library.GetValueOrDefault(b,0)+1;
        }
        else
        {
            library.Add(b,1);
        }

        return b;
    }

    public Members CreateMember(string name)
    {
        Members m = new Members(name);
        return m;
    }

    public void Issue(Book b, Members m){
        if (m.BooksCheckout.Count >= 3)
        {
            throw new BorrowLimitExceeded("u cant issue more than three books");
        }

        if (!library.ContainsKey(b))
        {
            throw new BookDoesntExist("book doesn't exist in library");
        }

        if (library[b] <= 0)
        {
            throw new BookDoesntExist("current book doenst exist in library");
        }

        BorrowedBooks bb = new BorrowedBooks(m, b);
            library[b]=library.GetValueOrDefault(b,0)-1;
            m.BooksCheckout.Add(b);
            BooksBorrowed.Add(bb);
    }

    public void ReturnBook(BorrowedBooks book)
    {
        BorrowedBooks match = BooksBorrowed.Find(b => book.Equals(b));

        if (match == null)
        {
            throw new NotBorrowed("This book was not borrowed");
        }

        BooksBorrowed.Remove(match);
        library[match.book] = library.GetValueOrDefault(match.book, 0) + 1;
        match.member.BooksCheckout.Remove(match.book);
    }
}
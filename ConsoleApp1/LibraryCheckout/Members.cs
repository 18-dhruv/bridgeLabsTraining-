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

    public override bool Equals(object? obj)
    {
        if (obj is not Members m)
        {
            return false;
        }

        return Name == m.Name && MemberId == m.MemberId;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, MemberId);
    }
}
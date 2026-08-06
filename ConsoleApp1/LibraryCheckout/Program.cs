using System;
using LibraryCheckout;

namespace LibraryCheckout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Members m1 = new Members("Dhruv");
            Members m2 = new Members("Rahul");

            Book b1 = new Book("Atomic Habits", "James Clear");
            Book b2 = new Book("Clean Code", "Robert C. Martin");

            BorrowedBooks bb1 = new BorrowedBooks(m1, b1);
            BorrowedBooks bb2 = new BorrowedBooks(m1, b1);
            BorrowedBooks bb3 = new BorrowedBooks(m2, b1);
            BorrowedBooks bb4 = new BorrowedBooks(m1, b2);

            Console.WriteLine("bb1 == bb2 (Same member & same book):");
            Console.WriteLine(bb1.Equals(bb2));     // True

            Console.WriteLine();

            Console.WriteLine("bb1 == bb3 (Different member):");
            Console.WriteLine(bb1.Equals(bb3));     // False

            Console.WriteLine();

            Console.WriteLine("bb1 == bb4 (Different book):");
            Console.WriteLine(bb1.Equals(bb4));     // False

            Console.WriteLine();

            Console.WriteLine("Comparing with null:");
            Console.WriteLine(bb1.Equals(null));    // False

            Console.WriteLine();

            Console.WriteLine("Details:");
            Console.WriteLine(bb1.returnName(bb1));
            Console.WriteLine(bb3.returnName(bb3));
        }
    }
}
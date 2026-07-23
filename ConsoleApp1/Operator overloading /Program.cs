using System;

namespace tickets
{


   public class Ticket
   { 
       int price;

       public Ticket(int price)
       {
           this.price = price;
       }

     
       

       public static Ticket operator +(Ticket a, Ticket b)
       {
           return new Ticket(a.price + b.price);
       }

       public override string ToString()
       {
           return $"Ticket price: {price}";
       }




      public static void Main(string[] args)
       {
           Ticket a = new Ticket(100);
           Ticket b = new Ticket(200);
           Console.WriteLine(a+b);
       }
    }
}

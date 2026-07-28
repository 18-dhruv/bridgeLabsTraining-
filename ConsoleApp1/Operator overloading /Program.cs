using System;
using System.Runtime.InteropServices.JavaScript;
using arrays;

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
            // Ticket a = new Ticket(100);
            // Ticket b = new Ticket(200);
            // Console.WriteLine(a+b);
            // int []arr =  {1, 2, 3, 4, 5, 6, 7};
            // arr = arrays.arrays.RotateArray(arr, 3);
            // foreach( int i in arr)
            // {
            //     Console.WriteLine(i);
            // }
            // Console.WriteLine(arrays.arrays.Reversenum(156));
            // Console.WriteLine(arrays.arrays.IsPalindrome(-12431));
            // Console.WriteLine(arrays.arrays.IsAnagram("hello","leloh"));
            //arrays.Array_2D.matrixIteration();
            // arrays.Array_2D.RectangularAraay(2, 2);
            // Operator_overloading.helloWorld.hello();
            Pattern1.Patter.pattern4();
        }
    }

    namespace Pattern1
    {
        public class Patter
        {
//*
//**
//***
//****
//*****
            static void Pattern1(int n)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write("*");
                    }

                    Console.WriteLine();
                }
            }


            // *****
            // ****
            // ***
            // **
            // *
            static void Pattern2(int n)
            {
                for (int i = n; i >= 0; i--)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write("*");
                    }

                    Console.WriteLine();
                }
            }

            //*****
            //*****
            //*****
            //*****
            //*****
            static void Pattern3(int n)
            {
                for (int i = 0; i <= n; i++)
                {
                    for (int j = 0; j <= n; i++)
                    {
                        Console.Write("*");
                    }
                }
            }

            static void Factorial(int n)
            {
                int fac = 1;
                for (int i = 2; i <= n; i++)
                {
                    fac *= i;
                }

                Console.WriteLine(fac);
            }

            static void LeapYear(int n)
            {
                if (n % 4 == 0)
                {
                    if (n % 100 == 0)
                    {
                        if (n % 400 == 0)
                        {
                            Console.WriteLine(n + " is a leap year");
                            return;
                        }

                        Console.WriteLine(n + " is not a leap year");
                        return;
                    }

                    Console.WriteLine(n + " is a leap year");
                    return;
                }

                Console.WriteLine(n + " is a not leap year");

            }

            public static void pattern4()
            {
                int a = 4;
                int b = a;
                
                for (int i = 0; i <= a; i++)
                {
                    int c = 0;
                    while (c < b)
                    {
                        Console.Write(" ");
                        c++;
                    }

                    b--;
                    for (int j = 0; j <= a; j++)
                    {
                        if (j ==0  || j == a-1)
                        {
                            Console.Write("*");
                            Console.Write(" ");
                        }
                        else
                        {
                            if (j != 0 || j != 1)
                            {
                                Console.Write(" ");
                            }
                            else
                            {
                                Console.Write("*");
                            }
                        }
                    }
                    Console.WriteLine();
                }
            }

        }
    }
}

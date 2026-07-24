using System;
using System.Globalization;

namespace Pattern;

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
            for (int j = 0; j<i;j++)
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
        for (int i = n; i>=0; i--)
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
    static void Factorial(int n){
        int fac=1;
        for(int i =2;i<=n;i++){
        fac*=i;
        }
        Console.WriteLine(fac);
        }

        static void LeapYear(int n){
            if(n%4==0){
                if(n%100==0){
                    if(n%400==0){
                        Console.WriteLine(n+" is a leap year");
                        return ;
                    }
                    Console.WriteLine(n+" is not a leap year");
                    return ;
                }
                Console.WriteLine(n+" is a leap year");
                return ;
            }
            Console.WriteLine(n+" is a not leap year");
            
        }

    static void Main(string[] args)
    {
        // Pattern1(5);
        // Pattern2(5);
        // Pattern3(5);
        // Factorial(3);
        LeapYear(2000);
    }
}
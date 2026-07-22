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
    static void patter2(int n)
    {
        for (int i = n; i>0; i--)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }  
    }

    static void Main(string[] args)
    {
        // Pattern1(3);
    }
}
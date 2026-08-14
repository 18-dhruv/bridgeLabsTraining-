using System;

namespace Regres;

public class program
{
    public static void Main(string[] args)
    {
        IStringCleaner verifier = new EmailVerifier();

        Console.Write("Enter an email: ");
        string input = Console.ReadLine() ?? "";

        bool result = verifier.IsStringCorrect(input);

        Console.WriteLine(result
            ? "Valid email address."
            : "Invalid email address.");
    }
}
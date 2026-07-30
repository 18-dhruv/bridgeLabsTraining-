using System;

public class Methods
{
    // 1. Simple method
    public void Greet()
    {
        Console.WriteLine("Hello");
        Console.WriteLine("How do you do?");
    }

    // 2. Method with return value
    public static double ConvertKmToMiles(double km)
    {
        return km * 0.621371;
    }

    // 3. Recursive method
    public static int Factorial(int n)
    {
        if (n == 0) return 1;
        return n * Factorial(n - 1);
    }

    // 4. Count digits
    public static int CountDigits(int number)
    {
        int count = 0;
        while (number > 0)
        {
            count++;
            number /= 10;
        }
        return count;
    }

    // 5. Get digits
    public static int[] GetDigits(int number)
    {
        int count = CountDigits(number);
        int[] digits = new int[count];

        for (int i = count - 1; i >= 0; i--)
        {
            digits[i] = number % 10;
            number /= 10;
        }

        return digits;
    }

    // 6. Sum array
    public static int SumArray(int[] array)
    {
        int sum = 0;
        foreach (int num in array)
            sum += num;
        return sum;
    }

    public static void Main()
    {
        Methods obj = new Methods();
        obj.Greet();

        Console.WriteLine(ConvertKmToMiles(10));
        Console.WriteLine(Factorial(5));

        int number = 1234;
        Console.WriteLine($"Digits: {CountDigits(number)}");
        Console.WriteLine($"Sum: {SumArray(GetDigits(number))}");
    }
}

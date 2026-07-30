using System;

public class Methods
{

    public void Greet()
    {
        Console.WriteLine("Hello");
        Console.WriteLine("How do you do?");
    }

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


    public static int SumArray(int[] array)
    {
        int sum = 0;
        foreach (int num in array)
            sum += num;
        return sum;
    }
}

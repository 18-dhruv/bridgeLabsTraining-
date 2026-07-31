using System;

public class BuiltInMethod
{
    public static int Get4DigitRandomNumber()
    {
        Random random = new Random();
        return random.Next(1000, 10000);
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

    public static int[] GetDigits(int number, int count)
    {
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
        foreach (int digit in array)
            sum += digit;
        return sum;
    }
}

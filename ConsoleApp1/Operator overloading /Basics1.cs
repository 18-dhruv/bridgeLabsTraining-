using System;

public class Basics1
{
    // 1. Welcome to Bridgelabz
    public static void Welcome()
    {
        Console.WriteLine("Welcome to Bridgelabz!");
    }

    // 2. Add Two Numbers
    public static void AddTwoNumbers()
    {
        Console.Write("Enter first number: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Sum = " + (a + b));
    }

    // 3. Celsius to Fahrenheit
    public static void CelsiusToFahrenheit()
    {
        Console.Write("Enter temperature in Celsius: ");
        double c = Convert.ToDouble(Console.ReadLine());

        double f = (c * 9 / 5) + 32;
        Console.WriteLine("Fahrenheit = " + f);
    }

    // 4. Area of Circle
    public static void AreaOfCircle()
    {
        Console.Write("Enter radius: ");
        double r = Convert.ToDouble(Console.ReadLine());

        double area = Math.PI * Math.Pow(r, 2);
        Console.WriteLine("Area = " + area);
    }

    // 5. Volume of Cylinder
    public static void VolumeOfCylinder()
    {
        Console.Write("Enter radius: ");
        double r = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter height: ");
        double h = Convert.ToDouble(Console.ReadLine());

        double volume = Math.PI * Math.Pow(r, 2) * h;
        Console.WriteLine("Volume = " + volume);
    }

    // 6. Simple Interest
    public static void SimpleInterest()
    {
        Console.Write("Principal: ");
        double p = Convert.ToDouble(Console.ReadLine());

        Console.Write("Rate: ");
        double rate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Time: ");
        double t = Convert.ToDouble(Console.ReadLine());

        double si = (p * rate * t) / 100;
        Console.WriteLine("Simple Interest = " + si);
    }

    // 7. Perimeter of Rectangle
    public static void PerimeterOfRectangle()
    {
        Console.Write("Length: ");
        double l = Convert.ToDouble(Console.ReadLine());

        Console.Write("Width: ");
        double w = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Perimeter = " + (2 * (l + w)));
    }

    // 8. Power Calculation
    public static void PowerCalculation()
    {
        Console.Write("Base: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Exponent: ");
        double e = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Result = " + Math.Pow(b, e));
    }

    // 9. Average of Three Numbers
    public static void AverageOfThreeNumbers()
    {
        Console.Write("First: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Second: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Third: ");
        double c = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Average = " + ((a + b + c) / 3));
    }

    // 10. Kilometers to Miles
    public static void KilometersToMiles()
    {
        Console.Write("Kilometers: ");
        double km = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Miles = " + (km * 0.621371));
    }
    
    }


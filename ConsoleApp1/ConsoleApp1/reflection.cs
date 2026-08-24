namespace ConsoleApp1;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

public class ReflectionOperations
{
    // ============================================================
    // 1. Get Class Information
    // ============================================================

    public void GetClassInformation(string className)
    {
        try
        {
            Type? type = Type.GetType(className);

            if (type == null)
            {
                Console.WriteLine("Class not found.");
                return;
            }

            Console.WriteLine($"Class: {type.Name}");

            Console.WriteLine("\nConstructors:");

            foreach (ConstructorInfo constructor in type.GetConstructors())
            {
                Console.WriteLine(constructor);
            }

            Console.WriteLine("\nFields:");

            foreach (FieldInfo field in type.GetFields(
                         BindingFlags.Public |
                         BindingFlags.NonPublic |
                         BindingFlags.Instance |
                         BindingFlags.Static))
            {
                Console.WriteLine(
                    $"{field.FieldType.Name} {field.Name}"
                );
            }

            Console.WriteLine("\nMethods:");

            foreach (MethodInfo method in type.GetMethods(
                         BindingFlags.Public |
                         BindingFlags.NonPublic |
                         BindingFlags.Instance |
                         BindingFlags.Static))
            {
                Console.WriteLine(method);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    // ============================================================
    // 2. Access Private Field
    // ============================================================

    public void AccessPrivateField()
    {
        try
        {
            Person person = new Person();

            Type type = typeof(Person);

            FieldInfo? field = type.GetField(
                "age",
                BindingFlags.NonPublic |
                BindingFlags.Instance
            );

            if (field == null)
            {
                Console.WriteLine("Field not found.");
                return;
            }

            // Modify private field
            field.SetValue(person, 25);

            // Retrieve private field
            int age = (int)field.GetValue(person)!;

            Console.WriteLine($"Age: {age}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    // ============================================================
    // 3. Invoke Private Method
    // ============================================================

    public void InvokePrivateMethod()
    {
        try
        {
            Calculator calculator = new Calculator();

            Type type = typeof(Calculator);

            MethodInfo? method = type.GetMethod(
                "Multiply",
                BindingFlags.NonPublic |
                BindingFlags.Instance
            );

            if (method == null)
            {
                Console.WriteLine("Method not found.");
                return;
            }

            object? result = method.Invoke(
                calculator,
                new object[] { 5, 10 }
            );

            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    // ============================================================
    // 4. Dynamically Create Objects
    // ============================================================

    public void CreateStudentDynamically()
    {
        try
        {
            Type type = typeof(Student);

            object? student =
                Activator.CreateInstance(type);

            if (student == null)
            {
                Console.WriteLine("Could not create object.");
                return;
            }

            Console.WriteLine(
                $"Object created: {student.GetType().Name}"
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    // ============================================================
    // 5. Dynamic Method Invocation
    // ============================================================

    public void DynamicMethodInvocation(
        string methodName,
        int a,
        int b)
    {
        try
        {
            MathOperations math = new MathOperations();

            Type type = typeof(MathOperations);

            MethodInfo? method =
                type.GetMethod(methodName);

            if (method == null)
            {
                Console.WriteLine("Method not found.");
                return;
            }

            object? result = method.Invoke(
                math,
                new object[] { a, b }
            );

            Console.WriteLine(
                $"{methodName}({a}, {b}) = {result}"
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    // ============================================================
    // 6. Retrieve Custom Attribute
    // ============================================================

    public void GetAuthorAttribute()
    {
        Type type = typeof(Book);

        AuthorAttribute? attribute =
            type.GetCustomAttribute<AuthorAttribute>();

        if (attribute != null)
        {
            Console.WriteLine(
                $"Author: {attribute.Name}"
            );
        }
        else
        {
            Console.WriteLine("Author attribute not found.");
        }
    }


    // ============================================================
    // 7. Access and Modify Static Field
    // ============================================================

    public void ModifyStaticField()
    {
        try
        {
            Type type = typeof(Configuration);

            FieldInfo? field = type.GetField(
                "API_KEY",
                BindingFlags.NonPublic |
                BindingFlags.Static
            );

            if (field == null)
            {
                Console.WriteLine("Field not found.");
                return;
            }

            field.SetValue(
                null,
                "NEW_API_KEY_123"
            );

            string? apiKey =
                field.GetValue(null)?.ToString();

            Console.WriteLine($"API Key: {apiKey}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    // ============================================================
    // 8. Custom Object Mapper
    // ============================================================

    public T ToObject<T>(
        Type clazz,
        Dictionary<string, object> properties)
    {
        object? obj =
            Activator.CreateInstance(clazz);

        if (obj == null)
        {
            throw new Exception("Could not create object.");
        }

        foreach (var property in properties)
        {
            FieldInfo? field = clazz.GetField(
                property.Key,
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance
            );

            if (field != null)
            {
                field.SetValue(
                    obj,
                    property.Value
                );
            }
        }

        return (T)obj;
    }


    // ============================================================
    // 9. Generate JSON-like Representation
    // ============================================================

    public string ToJson(object obj)
    {
        Type type = obj.GetType();

        FieldInfo[] fields = type.GetFields(
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Instance
        );

        List<string> values = new List<string>();

        foreach (FieldInfo field in fields)
        {
            object? value = field.GetValue(obj);

            string valueString =
                value is string
                    ? $"\"{value}\""
                    : value?.ToString() ?? "null";

            values.Add(
                $"\"{field.Name}\": {valueString}"
            );
        }

        return "{ " +
               string.Join(", ", values) +
               " }";
    }


    // ============================================================
    // 10. Custom Logging Proxy
    // ============================================================

    public void LoggingProxy()
    {
        IGreeting greeting =
            new Greeting();

        MethodInfo? method =
            typeof(IGreeting).GetMethod("SayHello");

        if (method == null)
        {
            Console.WriteLine("Method not found.");
            return;
        }

        Console.WriteLine(
            $"Calling method: {method.Name}"
        );

        method.Invoke(
            greeting,
            new object[] { "Dhruv" }
        );
    }


    // ============================================================
    // 11. Simple Dependency Injection
    // ============================================================

    public void DependencyInjection()
    {
        try
        {
            DIContainer container =
                new DIContainer();

            UserService service =
                container.Resolve<UserService>();

            service.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"DI Error: {ex.Message}"
            );
        }
    }


    // ============================================================
    // 12. Method Execution Timing
    // ============================================================

    public void MeasureExecutionTime(
        object obj,
        string methodName)
    {
        try
        {
            Type type = obj.GetType();

            MethodInfo? method =
                type.GetMethod(methodName);

            if (method == null)
            {
                Console.WriteLine("Method not found.");
                return;
            }

            Stopwatch stopwatch =
                Stopwatch.StartNew();

            method.Invoke(obj, null);

            stopwatch.Stop();

            Console.WriteLine(
                $"Method: {methodName}"
            );

            Console.WriteLine(
                $"Execution Time: " +
                $"{stopwatch.ElapsedMilliseconds} ms"
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}


// ================================================================
// Person
// ================================================================

public class Person
{
    private int age;
}


// ================================================================
// Calculator
// ================================================================

public class Calculator
{
    private int Multiply(int a, int b)
    {
        return a * b;
    }
}


// ================================================================
// Student
// ================================================================

public class Student
{
    public Student()
    {
        Console.WriteLine("Student constructor called.");
    }
}


// ================================================================
// Math Operations
// ================================================================

public class MathOperations
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }
}


// ================================================================
// Custom Attribute
// ================================================================

[AttributeUsage(AttributeTargets.Class)]
public class AuthorAttribute : Attribute
{
    public string Name { get; }

    public AuthorAttribute(string name)
    {
        Name = name;
    }
}


[Author("Dhruv")]
public class Book
{
    public string title = "C# Reflection";
}


// ================================================================
// Configuration
// ================================================================

public class Configuration
{
    private static string API_KEY =
        "OLD_API_KEY";
}


// ================================================================
// Greeting Interface
// ================================================================

public interface IGreeting
{
    void SayHello(string name);
}


public class Greeting : IGreeting
{
    public void SayHello(string name)
    {
        Console.WriteLine(
            $"Hello {name}!"
        );
    }
}


// ================================================================
// Dependency Injection
// ================================================================

[AttributeUsage(AttributeTargets.Property)]
public class InjectAttribute : Attribute
{
}


public class EmailService
{
    public void SendEmail()
    {
        Console.WriteLine("Email sent.");
    }
}


public class UserService
{
    [Inject]
    public EmailService? EmailService { get; set; }

    public void Run()
    {
        EmailService?.SendEmail();
    }
}


public class DIContainer
{
    public T Resolve<T>()
    {
        Type type = typeof(T);

        object? instance =
            Activator.CreateInstance(type);

        if (instance == null)
        {
            throw new Exception(
                $"Could not create {type.Name}"
            );
        }

        PropertyInfo[] properties =
            type.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            bool hasInject =
                property.GetCustomAttribute<InjectAttribute>()
                != null;

            if (!hasInject)
            {
                continue;
            }

            Type dependencyType =
                property.PropertyType;

            object? dependency =
                Activator.CreateInstance(
                    dependencyType
                );

            property.SetValue(
                instance,
                dependency
            );
        }

        return (T)instance;
    }
}


// ================================================================
// Class for Execution Timing
// ================================================================

public class SlowOperations
{
    public void LongRunningMethod()
    {
        Thread.Sleep(1000);
    }
}
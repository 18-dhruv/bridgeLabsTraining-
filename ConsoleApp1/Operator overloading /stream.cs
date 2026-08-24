namespace Operator_overloading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

public class StreamOperations
{
    // ============================================================
    // 1. File Handling - Read and Write a Text File
    // ============================================================

    public void CopyTextFile(string sourcePath, string destinationPath)
    {
        try
        {
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist.");
                return;
            }

            using FileStream sourceStream = new FileStream(
                sourcePath,
                FileMode.Open,
                FileAccess.Read
            );

            using FileStream destinationStream = new FileStream(
                destinationPath,
                FileMode.Create,
                FileAccess.Write
            );

            int data;

            while ((data = sourceStream.ReadByte()) != -1)
            {
                destinationStream.WriteByte((byte)data);
            }

            Console.WriteLine("File copied successfully.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
    }


    // ============================================================
    // 2. Buffered Streams - Efficient File Copy
    // ============================================================

    public void CopyFileUsingBufferedStream(
        string sourcePath,
        string destinationPath)
    {
        try
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            using FileStream sourceFile = new FileStream(
                sourcePath,
                FileMode.Open,
                FileAccess.Read
            );

            using FileStream destinationFile = new FileStream(
                destinationPath,
                FileMode.Create,
                FileAccess.Write
            );

            using BufferedStream bufferedSource =
                new BufferedStream(sourceFile);

            using BufferedStream bufferedDestination =
                new BufferedStream(destinationFile);

            byte[] buffer = new byte[4096];

            int bytesRead;

            while ((bytesRead = bufferedSource.Read(buffer, 0, buffer.Length)) > 0)
            {
                bufferedDestination.Write(buffer, 0, bytesRead);
            }

            stopwatch.Stop();

            Console.WriteLine(
                $"Buffered Stream Time: {stopwatch.ElapsedMilliseconds} ms"
            );
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
    }


    // ============================================================
    // 3. Normal File Stream Copy
    // ============================================================

    public void CopyFileUsingNormalStream(
        string sourcePath,
        string destinationPath)
    {
        try
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            using FileStream sourceFile = new FileStream(
                sourcePath,
                FileMode.Open,
                FileAccess.Read
            );

            using FileStream destinationFile = new FileStream(
                destinationPath,
                FileMode.Create,
                FileAccess.Write
            );

            byte[] buffer = new byte[4096];

            int bytesRead;

            while ((bytesRead = sourceFile.Read(
                       buffer,
                       0,
                       buffer.Length)) > 0)
            {
                destinationFile.Write(
                    buffer,
                    0,
                    bytesRead
                );
            }

            stopwatch.Stop();

            Console.WriteLine(
                $"Normal FileStream Time: {stopwatch.ElapsedMilliseconds} ms"
            );
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
    }


    // ============================================================
    // 4. Read User Input from Console
    // ============================================================

    public void SaveUserInformation(string filePath)
    {
        try
        {
            using StreamReader reader =
                new StreamReader(Console.OpenStandardInput());

            Console.Write("Enter your name: ");
            string? name = reader.ReadLine();

            Console.Write("Enter your age: ");
            string? age = reader.ReadLine();

            Console.Write("Enter your favorite programming language: ");
            string? language = reader.ReadLine();

            using StreamWriter writer =
                new StreamWriter(filePath);

            writer.WriteLine($"Name: {name}");
            writer.WriteLine($"Age: {age}");
            writer.WriteLine($"Favorite Language: {language}");

            Console.WriteLine("User information saved successfully.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Input/Output error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    // ============================================================
    // 5. Serialization - Save Employees
    // ============================================================

    public void SerializeEmployees(
        List<Employee> employees,
        string filePath)
    {
        try
        {
            string json = JsonSerializer.Serialize(
                employees,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }
            );

            using FileStream fileStream = new FileStream(
                filePath,
                FileMode.Create,
                FileAccess.Write
            );

            using StreamWriter writer =
                new StreamWriter(fileStream);

            writer.Write(json);

            Console.WriteLine("Employees serialized successfully.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Serialization error: {ex.Message}");
        }
    }


    // ============================================================
    // 6. Deserialize Employees
    // ============================================================

    public List<Employee>? DeserializeEmployees(
        string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Employee file does not exist.");
                return null;
            }

            using FileStream fileStream = new FileStream(
                filePath,
                FileMode.Open,
                FileAccess.Read
            );

            using StreamReader reader =
                new StreamReader(fileStream);

            string json = reader.ReadToEnd();

            List<Employee>? employees =
                JsonSerializer.Deserialize<List<Employee>>(json);

            return employees;
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
            return null;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Deserialization error: {ex.Message}");
            return null;
        }
    }


    // ============================================================
    // 7. Display Employees
    // ============================================================

    public void DisplayEmployees(string filePath)
    {
        List<Employee>? employees =
            DeserializeEmployees(filePath);

        if (employees == null)
        {
            return;
        }

        foreach (Employee employee in employees)
        {
            Console.WriteLine(
                $"ID: {employee.Id}, " +
                $"Name: {employee.Name}, " +
                $"Department: {employee.Department}, " +
                $"Salary: {employee.Salary}"
            );
        }
    }


    // ============================================================
    // 8. ByteArray Stream - Convert Image to ByteArray
    // ============================================================

    public byte[] ImageToByteArray(string imagePath)
    {
        try
        {
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file does not exist.");
                return Array.Empty<byte>();
            }

            using FileStream fileStream = new FileStream(
                imagePath,
                FileMode.Open,
                FileAccess.Read
            );

            using MemoryStream memoryStream =
                new MemoryStream();

            fileStream.CopyTo(memoryStream);

            byte[] imageBytes =
                memoryStream.ToArray();

            Console.WriteLine(
                $"Image converted to byte array. " +
                $"Size: {imageBytes.Length} bytes"
            );

            return imageBytes;
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
            return Array.Empty<byte>();
        }
    }


    // ============================================================
    // 9. Convert ByteArray Back to Image/File
    // ============================================================

    public void ByteArrayToFile(
        byte[] data,
        string destinationPath)
    {
        try
        {
            using MemoryStream memoryStream =
                new MemoryStream(data);

            using FileStream fileStream =
                new FileStream(
                    destinationPath,
                    FileMode.Create,
                    FileAccess.Write
                );

            memoryStream.CopyTo(fileStream);

            Console.WriteLine(
                "Byte array successfully written to file."
            );
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
    }
}


// ================================================================
// Employee Class
// ================================================================

public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Department { get; set; } = "";

    public double Salary { get; set; }
}
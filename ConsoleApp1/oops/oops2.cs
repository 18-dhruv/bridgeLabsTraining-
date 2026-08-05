using System;

namespace OOPS2
{
    class BankAccount
    {
        public static string BankName = "State Bank";
        private static int totalAccounts = 0;

        public string AccountHolderName;
        public readonly int AccountNumber;

        public BankAccount(string AccountHolderName, int AccountNumber)
        {
            this.AccountHolderName = AccountHolderName;
            this.AccountNumber = AccountNumber;
            totalAccounts++;
        }

        public static void GetTotalAccounts() => Console.WriteLine($"Total Accounts : {totalAccounts}");

        public void Display()
        {
            Console.WriteLine($"Holder : {AccountHolderName}");
            Console.WriteLine($"Account Number : {AccountNumber}");
            Console.WriteLine($"Bank : {BankName}");
        }
    }

    class Book
    {
        public static string LibraryName = "Central Library";
        public string Title;
        public string Author;
        public readonly string ISBN;

        public Book(string Title, string Author, string ISBN)
        {
            this.Title = Title;
            this.Author = Author;
            this.ISBN = ISBN;
        }

        public static void DisplayLibraryName() => Console.WriteLine($"Library : {LibraryName}");

        public void Display()
        {
            Console.WriteLine($"Title : {Title}");
            Console.WriteLine($"Author : {Author}");
            Console.WriteLine($"ISBN : {ISBN}");
        }
    }

    class Employee
    {
        public static string CompanyName = "ABC Technologies";
        private static int totalEmployees = 0;

        public string Name;
        public readonly int Id;
        public string Designation;

        public Employee(string Name, int Id, string Designation)
        {
            this.Name = Name;
            this.Id = Id;
            this.Designation = Designation;
            totalEmployees++;
        }

        public static void DisplayTotalEmployees() => Console.WriteLine($"Total Employees : {totalEmployees}");

        public void Display()
        {
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"ID : {Id}");
            Console.WriteLine($"Designation : {Designation}");
        }
    }

    class Product
    {
        public static double Discount = 10;

        public string ProductName;
        public double Price;
        public int Quantity;
        public readonly int ProductID;

        public Product(string ProductName, double Price, int Quantity, int ProductID)
        {
            this.ProductName = ProductName;
            this.Price = Price;
            this.Quantity = Quantity;
            this.ProductID = ProductID;
        }

        public static void UpdateDiscount(double d) => Discount = d;

        public void Display()
        {
            Console.WriteLine($"Product : {ProductName}");
            Console.WriteLine($"ID : {ProductID}");
            Console.WriteLine($"Price : {Price}");
            Console.WriteLine($"Quantity : {Quantity}");
            Console.WriteLine($"Discount : {Discount}%");
        }
    }

    class Student
    {
        public static string UniversityName = "Chitkara University";
        private static int totalStudents = 0;

        public string Name;
        public readonly int RollNumber;
        public string Grade;

        public Student(string Name, int RollNumber, string Grade)
        {
            this.Name = Name;
            this.RollNumber = RollNumber;
            this.Grade = Grade;
            totalStudents++;
        }

        public static void DisplayTotalStudents() => Console.WriteLine($"Total Students : {totalStudents}");

        public void Display()
        {
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Roll Number : {RollNumber}");
            Console.WriteLine($"Grade : {Grade}");
        }
    }

    class Vehicle
    {
        public static double RegistrationFee = 5000;

        public string OwnerName;
        public string VehicleType;
        public readonly string RegistrationNumber;

        public Vehicle(string OwnerName, string VehicleType, string RegistrationNumber)
        {
            this.OwnerName = OwnerName;
            this.VehicleType = VehicleType;
            this.RegistrationNumber = RegistrationNumber;
        }

        public static void UpdateRegistrationFee(double fee) => RegistrationFee = fee;

        public void Display()
        {
            Console.WriteLine($"Owner : {OwnerName}");
            Console.WriteLine($"Vehicle : {VehicleType}");
            Console.WriteLine($"Registration Number : {RegistrationNumber}");
            Console.WriteLine($"Fee : {RegistrationFee}");
        }
    }

    class Patient
    {
        public static string HospitalName = "City Hospital";
        private static int totalPatients = 0;

        public string Name;
        public int Age;
        public string Ailment;
        public readonly int PatientID;

        public Patient(string Name, int Age, string Ailment, int PatientID)
        {
            this.Name = Name;
            this.Age = Age;
            this.Ailment = Ailment;
            this.PatientID = PatientID;
            totalPatients++;
        }

        public static void GetTotalPatients() => Console.WriteLine($"Total Patients : {totalPatients}");

        public void Display()
        {
            Console.WriteLine($"Patient : {Name}");
            Console.WriteLine($"ID : {PatientID}");
            Console.WriteLine($"Age : {Age}");
            Console.WriteLine($"Ailment : {Ailment}");
        }
    }

    
    
}

using System;

namespace InheritanceDemo
{
    // ----------------------------
    // 1. Animal Hierarchy
    // ----------------------------
    class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }

    class Dog : Animal
    {
        public Dog(string name, int age) : base(name, age) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} barks");
        }
    }

    class Cat : Animal
    {
        public Cat(string name, int age) : base(name, age) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} meows");
        }
    }

    class Bird : Animal
    {
        public Bird(string name, int age) : base(name, age) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} chirps");
        }
    }

    // ----------------------------
    // 2. Employee Management
    // ----------------------------
    class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public double Salary { get; set; }

        public Employee(string name, int id, double salary)
        {
            Name = name;
            Id = id;
            Salary = salary;
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Salary: {Salary}");
        }
    }

    class Manager : Employee
    {
        public int TeamSize { get; set; }

        public Manager(string name, int id, double salary, int teamSize)
            : base(name, id, salary)
        {
            TeamSize = teamSize;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Team Size: {TeamSize}");
        }
    }

    class Developer : Employee
    {
        public string ProgrammingLanguage { get; set; }

        public Developer(string name, int id, double salary, string language)
            : base(name, id, salary)
        {
            ProgrammingLanguage = language;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Language: {ProgrammingLanguage}");
        }
    }

    class Intern : Employee
    {
        public string InternshipDuration { get; set; }

        public Intern(string name, int id, double salary, string duration)
            : base(name, id, salary)
        {
            InternshipDuration = duration;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Duration: {InternshipDuration}");
        }
    }

    // ----------------------------
    // 3. Vehicle System
    // ----------------------------
    class Vehicle
    {
        public int MaxSpeed { get; set; }
        public string FuelType { get; set; }

        public Vehicle(int maxSpeed, string fuelType)
        {
            MaxSpeed = maxSpeed;
            FuelType = fuelType;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Speed: {MaxSpeed} km/h");
            Console.WriteLine($"Fuel: {FuelType}");
        }
    }

    class Car : Vehicle
    {
        public int SeatCapacity { get; set; }

        public Car(int maxSpeed, string fuelType, int seats)
            : base(maxSpeed, fuelType)
        {
            SeatCapacity = seats;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Car");
            base.DisplayInfo();
            Console.WriteLine($"Seats: {SeatCapacity}");
        }
    }

    class Truck : Vehicle
    {
        public int PayloadCapacity { get; set; }

        public Truck(int maxSpeed, string fuelType, int payload)
            : base(maxSpeed, fuelType)
        {
            PayloadCapacity = payload;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Truck");
            base.DisplayInfo();
            Console.WriteLine($"Payload: {PayloadCapacity} kg");
        }
    }

    class Motorcycle : Vehicle
    {
        public bool HasSidecar { get; set; }

        public Motorcycle(int maxSpeed, string fuelType, bool hasSidecar)
            : base(maxSpeed, fuelType)
        {
            HasSidecar = hasSidecar;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Motorcycle");
            base.DisplayInfo();
            Console.WriteLine($"Has Sidecar: {HasSidecar}");
        }
    }

   
        
    
}

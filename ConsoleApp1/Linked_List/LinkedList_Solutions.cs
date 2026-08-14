using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedListSolutions;

// 1. Singly Linked List: Student Record Management
public class StudentLinkedList
{
    private class Node
    {
        public int RollNumber;
        public string Name;
        public int Age;
        public string Grade;
        public Node? Next;

        public Node(int rollNumber, string name, int age, string grade)
        {
            RollNumber = rollNumber;
            Name = name;
            Age = age;
            Grade = grade;
        }
    }

    private Node? head;

    public void AddAtBeginning(int rollNumber, string name, int age, string grade)
    {
        Node node = new(rollNumber, name, age, grade) { Next = head };
        head = node;
    }

    public void AddAtEnd(int rollNumber, string name, int age, string grade)
    {
        Node node = new(rollNumber, name, age, grade);

        if (head == null)
        {
            head = node;
            return;
        }

        Node current = head;
        while (current.Next != null)
            current = current.Next;

        current.Next = node;
    }

    public void AddAtPosition(int position, int rollNumber, string name, int age, string grade)
    {
        if (position < 1)
            throw new ArgumentOutOfRangeException(nameof(position));

        if (position == 1)
        {
            AddAtBeginning(rollNumber, name, age, grade);
            return;
        }

        Node? current = head;
        for (int i = 1; i < position - 1 && current != null; i++)
            current = current.Next;

        if (current == null)
            throw new ArgumentOutOfRangeException(nameof(position));

        Node node = new(rollNumber, name, age, grade)
        {
            Next = current.Next
        };
        current.Next = node;
    }

    public bool DeleteByRollNumber(int rollNumber)
    {
        if (head == null)
            return false;

        if (head.RollNumber == rollNumber)
        {
            head = head.Next;
            return true;
        }

        Node current = head;
        while (current.Next != null)
        {
            if (current.Next.RollNumber == rollNumber)
            {
                current.Next = current.Next.Next;
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    public void SearchByRollNumber(int rollNumber)
    {
        Node? student = Find(rollNumber);

        if (student == null)
            Console.WriteLine("Student not found.");
        else
            Console.WriteLine($"{student.RollNumber} | {student.Name} | Age: {student.Age} | Grade: {student.Grade}");
    }

    private Node? Find(int rollNumber)
    {
        Node? current = head;
        while (current != null)
        {
            if (current.RollNumber == rollNumber)
                return current;
            current = current.Next;
        }
        return null;
    }

    public bool UpdateGrade(int rollNumber, string newGrade)
    {
        Node? student = Find(rollNumber);
        if (student == null)
            return false;

        student.Grade = newGrade;
        return true;
    }

    public void Display()
    {
        Node? current = head;

        while (current != null)
        {
            Console.WriteLine($"{current.RollNumber} | {current.Name} | Age: {current.Age} | Grade: {current.Grade}");
            current = current.Next;
        }
    }
}

// 2. Doubly Linked List: Movie Management System
public class MovieLinkedList
{
    private class Node
    {
        public string Title;
        public string Director;
        public int Year;
        public double Rating;
        public Node? Previous;
        public Node? Next;

        public Node(string title, string director, int year, double rating)
        {
            Title = title;
            Director = director;
            Year = year;
            Rating = rating;
        }
    }

    private Node? head;
    private Node? tail;

    public void AddAtBeginning(string title, string director, int year, double rating)
    {
        Node node = new(title, director, year, rating);

        if (head == null)
        {
            head = tail = node;
            return;
        }

        node.Next = head;
        head.Previous = node;
        head = node;
    }

    public void AddAtEnd(string title, string director, int year, double rating)
    {
        Node node = new(title, director, year, rating);

        if (tail == null)
        {
            head = tail = node;
            return;
        }

        node.Previous = tail;
        tail.Next = node;
        tail = node;
    }

    public void AddAtPosition(int position, string title, string director, int year, double rating)
    {
        if (position < 1)
            throw new ArgumentOutOfRangeException(nameof(position));

        if (position == 1)
        {
            AddAtBeginning(title, director, year, rating);
            return;
        }

        Node? current = head;
        for (int i = 1; i < position && current != null; i++)
            current = current.Next;

        if (current == null)
        {
            if (position == Count() + 1)
                AddAtEnd(title, director, year, rating);
            else
                throw new ArgumentOutOfRangeException(nameof(position));
            return;
        }

        Node node = new(title, director, year, rating)
        {
            Previous = current.Previous,
            Next = current
        };

        current.Previous!.Next = node;
        current.Previous = node;
    }

    public bool RemoveByTitle(string title)
    {
        Node? node = FindByTitle(title);
        if (node == null)
            return false;

        RemoveNode(node);
        return true;
    }

    private void RemoveNode(Node node)
    {
        if (node.Previous == null)
            head = node.Next;
        else
            node.Previous.Next = node.Next;

        if (node.Next == null)
            tail = node.Previous;
        else
            node.Next.Previous = node.Previous;

        node.Previous = null;
        node.Next = null;
    }

    private Node? FindByTitle(string title)
    {
        Node? current = head;
        while (current != null)
        {
            if (string.Equals(current.Title, title, StringComparison.OrdinalIgnoreCase))
                return current;
            current = current.Next;
        }
        return null;
    }

    public void SearchByDirector(string director)
    {
        Node? current = head;
        while (current != null)
        {
            if (current.Director.Contains(director, StringComparison.OrdinalIgnoreCase))
                Print(current);
            current = current.Next;
        }
    }

    public void SearchByRating(double rating)
    {
        Node? current = head;
        while (current != null)
        {
            if (Math.Abs(current.Rating - rating) < 0.0001)
                Print(current);
            current = current.Next;
        }
    }

    public bool UpdateRating(string title, double rating)
    {
        Node? movie = FindByTitle(title);
        if (movie == null)
            return false;

        movie.Rating = rating;
        return true;
    }

    public void DisplayForward()
    {
        Node? current = head;
        while (current != null)
        {
            Print(current);
            current = current.Next;
        }
    }

    public void DisplayReverse()
    {
        Node? current = tail;
        while (current != null)
        {
            Print(current);
            current = current.Previous;
        }
    }

    private static void Print(Node movie) =>
        Console.WriteLine($"{movie.Title} | {movie.Director} | {movie.Year} | Rating: {movie.Rating:F1}");

    private int Count()
    {
        int count = 0;
        Node? current = head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }
}

// 3. Circular Linked List: Task Scheduler
public class TaskSchedulerCircularList
{
    private class Node
    {
        public int TaskId;
        public string TaskName;
        public int Priority;
        public DateTime DueDate;
        public Node? Next;

        public Node(int taskId, string taskName, int priority, DateTime dueDate)
        {
            TaskId = taskId;
            TaskName = taskName;
            Priority = priority;
            DueDate = dueDate;
        }
    }

    private Node? head;
    private Node? tail;
    private Node? current;

    public void AddAtBeginning(int id, string name, int priority, DateTime dueDate)
    {
        Node node = new(id, name, priority, dueDate);

        if (head == null)
        {
            head = tail = node;
            node.Next = node;
            current = head;
            return;
        }

        node.Next = head;
        head = node;
        tail!.Next = head;
    }

    public void AddAtEnd(int id, string name, int priority, DateTime dueDate)
    {
        Node node = new(id, name, priority, dueDate);

        if (head == null)
        {
            head = tail = node;
            node.Next = node;
            current = head;
            return;
        }

        node.Next = head;
        tail!.Next = node;
        tail = node;
    }

    public void AddAtPosition(int position, int id, string name, int priority, DateTime dueDate)
    {
        if (position <= 0)
            throw new ArgumentOutOfRangeException(nameof(position));

        if (position == 1)
        {
            AddAtBeginning(id, name, priority, dueDate);
            return;
        }

        if (head == null)
            throw new ArgumentOutOfRangeException(nameof(position));

        Node previous = head;
        for (int i = 1; i < position - 1; i++)
        {
            if (previous.Next == head)
                throw new ArgumentOutOfRangeException(nameof(position));
            previous = previous.Next!;
        }

        Node node = new(id, name, priority, dueDate)
        {
            Next = previous.Next
        };
        previous.Next = node;

        if (previous == tail)
            tail = node;
    }

    public bool RemoveById(int id)
    {
        if (head == null)
            return false;

        Node previous = tail!;
        Node node = head;

        do
        {
            if (node.TaskId == id)
            {
                if (node == head && node == tail)
                {
                    head = tail = current = null;
                    return true;
                }

                previous.Next = node.Next;

                if (node == head)
                    head = node.Next;

                if (node == tail)
                    tail = previous;

                tail!.Next = head;

                if (current == node)
                    current = node.Next;

                return true;
            }

            previous = node;
            node = node.Next!;
        } while (node != head);

        return false;
    }

    public void ViewCurrentTask()
    {
        if (current == null)
        {
            Console.WriteLine("No tasks.");
            return;
        }

        Print(current);
    }

    public void MoveToNextTask()
    {
        if (current != null)
            current = current.Next;
    }

    public void Display()
    {
        if (head == null)
            return;

        Node node = head;
        do
        {
            Print(node);
            node = node.Next!;
        } while (node != head);
    }

    public void SearchByPriority(int priority)
    {
        if (head == null)
            return;

        Node node = head;
        do
        {
            if (node.Priority == priority)
                Print(node);

            node = node.Next!;
        } while (node != head);
    }

    private static void Print(Node task) =>
        Console.WriteLine($"{task.TaskId} | {task.TaskName} | Priority: {task.Priority} | Due: {task.DueDate:yyyy-MM-dd}");
}

// 4. Singly Linked List: Inventory Management System
public class InventoryLinkedList
{
    private class Node
    {
        public string ItemName;
        public int ItemId;
        public int Quantity;
        public decimal Price;
        public Node? Next;

        public Node(string itemName, int itemId, int quantity, decimal price)
        {
            ItemName = itemName;
            ItemId = itemId;
            Quantity = quantity;
            Price = price;
        }
    }

    private Node? head;

    public void AddAtBeginning(string name, int id, int quantity, decimal price)
    {
        head = new Node(name, id, quantity, price) { Next = head };
    }

    public void AddAtEnd(string name, int id, int quantity, decimal price)
    {
        Node node = new(name, id, quantity, price);

        if (head == null)
        {
            head = node;
            return;
        }

        Node current = head;
        while (current.Next != null)
            current = current.Next;

        current.Next = node;
    }

    public void AddAtPosition(int position, string name, int id, int quantity, decimal price)
    {
        if (position < 1)
            throw new ArgumentOutOfRangeException(nameof(position));

        if (position == 1)
        {
            AddAtBeginning(name, id, quantity, price);
            return;
        }

        Node? current = head;
        for (int i = 1; i < position - 1 && current != null; i++)
            current = current.Next;

        if (current == null)
            throw new ArgumentOutOfRangeException(nameof(position));

        current.Next = new Node(name, id, quantity, price) { Next = current.Next };
    }

    public bool RemoveById(int id)
    {
        if (head == null)
            return false;

        if (head.ItemId == id)
        {
            head = head.Next;
            return true;
        }

        Node current = head;
        while (current.Next != null)
        {
            if (current.Next.ItemId == id)
            {
                current.Next = current.Next.Next;
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    public bool UpdateQuantity(int id, int quantity)
    {
        Node? item = FindById(id);
        if (item == null)
            return false;

        item.Quantity = quantity;
        return true;
    }

    public void SearchById(int id)
    {
        Node? item = FindById(id);
        if (item == null)
            Console.WriteLine("Item not found.");
        else
            Print(item);
    }

    public void SearchByName(string name)
    {
        Node? current = head;
        while (current != null)
        {
            if (current.ItemName.Contains(name, StringComparison.OrdinalIgnoreCase))
                Print(current);
            current = current.Next;
        }
    }

    private Node? FindById(int id)
    {
        Node? current = head;
        while (current != null)
        {
            if (current.ItemId == id)
                return current;
            current = current.Next;
        }
        return null;
    }

    public decimal TotalValue()
    {
        decimal total = 0;
        Node? current = head;

        while (current != null)
        {
            total += current.Price * current.Quantity;
            current = current.Next;
        }

        return total;
    }

    public void SortByName(bool ascending = true)
    {
        Sort((a, b) => string.Compare(a.ItemName, b.ItemName, StringComparison.OrdinalIgnoreCase), ascending);
    }

    public void SortByPrice(bool ascending = true)
    {
        Sort((a, b) => a.Price.CompareTo(b.Price), ascending);
    }

    private void Sort(Comparison<Node> comparison, bool ascending)
    {
        if (head == null || head.Next == null)
            return;

        // Bubble sort by swapping node data.
        for (Node? i = head; i != null; i = i.Next)
        {
            for (Node? j = i.Next; j != null; j = j.Next)
            {
                int result = comparison(i, j);
                if ((ascending && result > 0) || (!ascending && result < 0))
                {
                    (i.ItemName, j.ItemName) = (j.ItemName, i.ItemName);
                    (i.ItemId, j.ItemId) = (j.ItemId, i.ItemId);
                    (i.Quantity, j.Quantity) = (j.Quantity, i.Quantity);
                    (i.Price, j.Price) = (j.Price, i.Price);
                }
            }
        }
    }

    public void Display()
    {
        Node? current = head;
        while (current != null)
        {
            Print(current);
            current = current.Next;
        }
    }

    private static void Print(Node item) =>
        Console.WriteLine($"{item.ItemId} | {item.ItemName} | Qty: {item.Quantity} | Price: {item.Price:C}");
}

// 5. Doubly Linked List: Library Management System
public class LibraryLinkedList
{
    private class Node
    {
        public string Title;
        public string Author;
        public string Genre;
        public int BookId;
        public bool Available;
        public Node? Previous;
        public Node? Next;

        public Node(string title, string author, string genre, int bookId, bool available)
        {
            Title = title;
            Author = author;
            Genre = genre;
            BookId = bookId;
            Available = available;
        }
    }

    private Node? head;
    private Node? tail;

    public void AddAtBeginning(string title, string author, string genre, int id, bool available)
    {
        Node node = new(title, author, genre, id, available);

        if (head == null)
        {
            head = tail = node;
            return;
        }

        node.Next = head;
        head.Previous = node;
        head = node;
    }

    public void AddAtEnd(string title, string author, string genre, int id, bool available)
    {
        Node node = new(title, author, genre, id, available);

        if (tail == null)
        {
            head = tail = node;
            return;
        }

        node.Previous = tail;
        tail.Next = node;
        tail = node;
    }

    public void AddAtPosition(int position, string title, string author, string genre, int id, bool available)
    {
        if (position < 1)
            throw new ArgumentOutOfRangeException(nameof(position));

        if (position == 1)
        {
            AddAtBeginning(title, author, genre, id, available);
            return;
        }

        Node? current = head;
        for (int i = 1; i < position && current != null; i++)
            current = current.Next;

        if (current == null)
        {
            if (position == Count() + 1)
                AddAtEnd(title, author, genre, id, available);
            else
                throw new ArgumentOutOfRangeException(nameof(position));
            return;
        }

        Node node = new(title, author, genre, id, available)
        {
            Previous = current.Previous,
            Next = current
        };

        current.Previous!.Next = node;
        current.Previous = node;
    }

    public bool RemoveById(int id)
    {
        Node? node = FindById(id);
        if (node == null)
            return false;

        if (node.Previous == null)
            head = node.Next;
        else
            node.Previous.Next = node.Next;

        if (node.Next == null)
            tail = node.Previous;
        else
            node.Next.Previous = node.Previous;

        return true;
    }

    public void SearchByTitle(string title)
    {
        Node? current = head;
        while (current != null)
        {
            if (current.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                Print(current);
            current = current.Next;
        }
    }

    public void SearchByAuthor(string author)
    {
        Node? current = head;
        while (current != null)
        {
            if (current.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                Print(current);
            current = current.Next;
        }
    }

    public bool UpdateAvailability(int id, bool available)
    {
        Node? book = FindById(id);
        if (book == null)
            return false;

        book.Available = available;
        return true;
    }

    public void DisplayForward()
    {
        Node? current = head;
        while (current != null)
        {
            Print(current);
            current = current.Next;
        }
    }

    public void DisplayReverse()
    {
        Node? current = tail;
        while (current != null)
        {
            Print(current);
            current = current.Previous;
        }
    }

    public int Count() 
    {
        int count = 0;
        Node? current = head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }

    private Node? FindById(int id)
    {
        Node? current = head;
        while (current != null)
        {
            if (current.BookId == id)
                return current;
            current = current.Next;
        }
        return null;
    }

    private static void Print(Node book) =>
        Console.WriteLine($"{book.BookId} | {book.Title} | {book.Author} | {book.Genre} | {(book.Available ? "Available" : "Borrowed")}");
}

// 6. Circular Linked List: Round Robin Scheduling
public class RoundRobinScheduler
{
    private class Process
    {
        public int ProcessId;
        public int BurstTime;
        public int RemainingTime;
        public int Priority;
        public int WaitingTime;
        public int CompletionTime;
        public Process? Next;

        public Process(int id, int burstTime, int priority)
        {
            ProcessId = id;
            BurstTime = burstTime;
            RemainingTime = burstTime;
            Priority = priority;
        }
    }

    private Process? tail;
    private int processCount;

    public void AddProcess(int id, int burstTime, int priority)
    {
        if (burstTime < 0)
            throw new ArgumentOutOfRangeException(nameof(burstTime));

        Process process = new(id, burstTime, priority);

        if (tail == null)
        {
            tail = process;
            process.Next = process;
        }
        else
        {
            process.Next = tail.Next;
            tail.Next = process;
            tail = process;
        }

        processCount++;
    }

    public bool RemoveProcess(int id)
    {
        if (tail == null)
            return false;

        Process previous = tail;
        Process current = tail.Next!;

        do
        {
            if (current.ProcessId == id)
            {
                if (current == previous)
                    tail = null;
                else
                {
                    previous.Next = current.Next;
                    if (current == tail)
                        tail = previous;
                }

                processCount--;
                return true;
            }

            previous = current;
            current = current.Next!;
        } while (current != tail.Next);

        return false;
    }

    public void Schedule(int quantum)
    {
        if (quantum <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantum));

        if (tail == null)
        {
            Console.WriteLine("No processes.");
            return;
        }

        int time = 0;
        int remainingProcesses = processCount;
        Process? current = tail.Next;

        while (remainingProcesses > 0 && current != null)
        {
            int runTime = Math.Min(quantum, current.RemainingTime);
            time += runTime;
            current.RemainingTime -= runTime;

            Console.WriteLine(
                $"P{current.ProcessId} ran for {runTime}. Remaining: {current.RemainingTime}");

            if (current.RemainingTime == 0)
            {
                current.CompletionTime = time;
                current.WaitingTime = current.CompletionTime - current.BurstTime;
                remainingProcesses--;

                int completedId = current.ProcessId;
                Process? next = current.Next;

                if (next == current)
                {
                    current = null;
                    tail = null;
                    break;
                }

                RemoveProcess(completedId);
                current = next;
            }
            else
            {
                current = current.Next;
            }

            Console.WriteLine("Processes after round:");
            Display();
        }
    }

    public double AverageWaitingTime()
    {
        List<Process> processes = GetProcesses();
        if (processes.Count == 0)
            return 0;

        return processes.Average(p => p.WaitingTime);
    }

    public double AverageTurnaroundTime()
    {
        List<Process> processes = GetProcesses();
        if (processes.Count == 0)
            return 0;

        return processes.Average(p => p.CompletionTime);
    }

    private List<Process> GetProcesses()
    {
        // This method returns the currently stored processes. After Schedule,
        // completed processes have been removed, so averages should be captured
        // before scheduling if historical values are required.
        List<Process> result = new();

        if (tail == null)
            return result;

        Process start = tail.Next!;
        Process current = start;

        do
        {
            result.Add(current);
            current = current.Next!;
        } while (current != start);

        return result;
    }

    public void Display()
    {
        if (tail == null)
        {
            Console.WriteLine("No processes.");
            return;
        }

        Process start = tail.Next!;
        Process current = start;

        do
        {
            Console.Write($"P{current.ProcessId}(Burst={current.BurstTime}, Remaining={current.RemainingTime})");
            current = current.Next!;

            if (current != start)
                Console.Write(" -> ");
        } while (current != start);

        Console.WriteLine();
    }
}

// 7. Singly Linked List: Social Media Friend Connections
public class SocialMediaUsers
{
    private class UserNode
    {
        public int UserId;
        public string Name;
        public int Age;
        public HashSet<int> FriendIds = new();
        public UserNode? Next;

        public UserNode(int id, string name, int age)
        {
            UserId = id;
            Name = name;
            Age = age;
        }
    }

    private UserNode? head;

    public void AddUser(int id, string name, int age)
    {
        if (FindUser(id) != null)
            throw new InvalidOperationException("User ID already exists.");

        UserNode node = new(id, name, age);

        if (head == null)
        {
            head = node;
            return;
        }

        UserNode current = head;
        while (current.Next != null)
            current = current.Next;

        current.Next = node;
    }

    public bool AddFriendConnection(int userId1, int userId2)
    {
        UserNode? user1 = FindUser(userId1);
        UserNode? user2 = FindUser(userId2);

        if (user1 == null || user2 == null || userId1 == userId2)
            return false;

        user1.FriendIds.Add(userId2);
        user2.FriendIds.Add(userId1);
        return true;
    }

    public bool RemoveFriendConnection(int userId1, int userId2)
    {
        UserNode? user1 = FindUser(userId1);
        UserNode? user2 = FindUser(userId2);

        if (user1 == null || user2 == null)
            return false;

        bool removed = user1.FriendIds.Remove(userId2);
        user2.FriendIds.Remove(userId1);
        return removed;
    }

    public List<string> MutualFriends(int userId1, int userId2)
    {
        UserNode? user1 = FindUser(userId1);
        UserNode? user2 = FindUser(userId2);

        if (user1 == null || user2 == null)
            return new List<string>();

        HashSet<int> mutualIds = user1.FriendIds.Intersect(user2.FriendIds).ToHashSet();

        return mutualIds
            .Select(id => FindUser(id)?.Name)
            .Where(name => name != null)
            .Cast<string>()
            .ToList();
    }

    public void DisplayFriends(int userId)
    {
        UserNode? user = FindUser(userId);

        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        foreach (int friendId in user.FriendIds)
        {
            UserNode? friend = FindUser(friendId);
            if (friend != null)
                Console.WriteLine($"{friend.UserId} | {friend.Name} | Age: {friend.Age}");
        }
    }

    public UserInfo? SearchByName(string name)
    {
        UserNode? current = head;

        while (current != null)
        {
            if (current.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                return new UserInfo(current.UserId, current.Name, current.Age, current.FriendIds.Count);

            current = current.Next;
        }

        return null;
    }

    public UserInfo? SearchById(int id)
    {
        UserNode? user = FindUser(id);

        return user == null
            ? null
            : new UserInfo(user.UserId, user.Name, user.Age, user.FriendIds.Count);
    }

    public Dictionary<int, int> CountFriends()
    {
        Dictionary<int, int> result = new();
        UserNode? current = head;

        while (current != null)
        {
            result[current.UserId] = current.FriendIds.Count;
            current = current.Next;
        }

        return result;
    }

    private UserNode? FindUser(int id)
    {
        UserNode? current = head;

        while (current != null)
        {
            if (current.UserId == id)
                return current;

            current = current.Next;
        }

        return null;
    }

    public record UserInfo(int UserId, string Name, int Age, int FriendCount);
}

// 8. Doubly Linked List: Undo/Redo Text Editor
public class TextEditorHistory
{
    private class StateNode
    {
        public string Text;
        public StateNode? Previous;
        public StateNode? Next;

        public StateNode(string text)
        {
            Text = text;
        }
    }

    private readonly int maxHistory;
    private StateNode? head;
    private StateNode? tail;
    private StateNode? current;
    private int count;

    public TextEditorHistory(string initialText = "", int maxHistory = 10)
    {
        if (maxHistory <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxHistory));

        this.maxHistory = maxHistory;

        StateNode initial = new(initialText);
        head = tail = current = initial;
        count = 1;
    }

    public string CurrentText => current?.Text ?? "";

    public void AddState(string text)
    {
        if (current == null)
            return;

        // Remove redo states.
        current.Next = null;
        tail = current;

        StateNode node = new(text)
        {
            Previous = current
        };

        current.Next = node;
        current = tail = node;
        count++;

        while (count > maxHistory)
        {
            head = head?.Next;
            if (head != null)
                head.Previous = null;
            count--;
        }
    }

    public bool Undo()
    {
        if (current?.Previous == null)
            return false;

        current = current.Previous;
        return true;
    }

    public bool Redo()
    {
        if (current?.Next == null)
            return false;

        current = current.Next;
        return true;
    }

    public void DisplayCurrentState() =>
        Console.WriteLine($"Current text: {CurrentText}");
}

// 9. Circular Linked List: Online Ticket Reservation System
public class TicketReservationSystem
{
    private class TicketNode
    {
        public int TicketId;
        public string CustomerName;
        public string MovieName;
        public string SeatNumber;
        public DateTime BookingTime;
        public TicketNode? Next;

        public TicketNode(int ticketId, string customerName, string movieName,
            string seatNumber, DateTime bookingTime)
        {
            TicketId = ticketId;
            CustomerName = customerName;
            MovieName = movieName;
            SeatNumber = seatNumber;
            BookingTime = bookingTime;
        }
    }

    private TicketNode? tail;

    public void AddReservation(int ticketId, string customerName, string movieName,
        string seatNumber, DateTime bookingTime)
    {
        TicketNode node = new(ticketId, customerName, movieName, seatNumber, bookingTime);

        if (tail == null)
        {
            tail = node;
            node.Next = node;
            return;
        }

        node.Next = tail.Next;
        tail.Next = node;
        tail = node;
    }

    public bool RemoveTicket(int ticketId)
    {
        if (tail == null)
            return false;

        TicketNode previous = tail;
        TicketNode current = tail.Next!;

        do
        {
            if (current.TicketId == ticketId)
            {
                if (current == previous)
                    tail = null;
                else
                {
                    previous.Next = current.Next;
                    if (current == tail)
                        tail = previous;
                }

                return true;
            }

            previous = current;
            current = current.Next!;
        } while (current != tail.Next);

        return false;
    }

    public void DisplayTickets()
    {
        if (tail == null)
        {
            Console.WriteLine("No booked tickets.");
            return;
        }

        TicketNode start = tail.Next!;
        TicketNode current = start;

        do
        {
            Print(current);
            current = current.Next!;
        } while (current != start);
    }

    public void SearchByCustomerName(string customerName)
    {
        Search(ticket => ticket.CustomerName.Contains(customerName, StringComparison.OrdinalIgnoreCase));
    }

    public void SearchByMovieName(string movieName)
    {
        Search(ticket => ticket.MovieName.Contains(movieName, StringComparison.OrdinalIgnoreCase));
    }

    private void Search(Func<TicketNode, bool> predicate)
    {
        if (tail == null)
            return;

        TicketNode start = tail.Next!;
        TicketNode current = start;

        do
        {
            if (predicate(current))
                Print(current);

            current = current.Next!;
        } while (current != start);
    }

    public int TotalBookedTickets()
    {
        if (tail == null)
            return 0;

        int count = 0;
        TicketNode start = tail.Next!;
        TicketNode current = start;

        do
        {
            count++;
            current = current.Next!;
        } while (current != start);

        return count;
    }

    private static void Print(TicketNode ticket) =>
        Console.WriteLine(
            $"Ticket {ticket.TicketId} | {ticket.CustomerName} | {ticket.MovieName} | Seat: {ticket.SeatNumber} | {ticket.BookingTime}");
}

// The assignment contains data-structure implementations rather than one required
// console workflow. The classes above expose all requested operations and can be
// instantiated from any Program.cs.`

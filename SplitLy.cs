using System;
using System.Collections.Generic;
using System.IO;

class Participant
{
    public string Name { get; set; }
    public decimal Paid { get; set; }
}

class SplitLy
{
    private List<Participant> participants = new List<Participant>();
    private decimal totalBill;
    private int mode;
    private bool hasData = false;
    private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "splitly_data.txt");

    public void Start()
    {
        while (true)
        {
            ShowMainMenu();
        }
    }

    private void ShowMainMenu()
    {
        Console.Clear();

        Console.WriteLine("=========== SPLITLY ===========\n");

        Console.WriteLine("1. Create New Bill");
        Console.WriteLine("2. View Last Settlement");
        Console.WriteLine("3. Load Last From File");
        Console.WriteLine("4. View All Saved Bills");
        Console.WriteLine("5. Exit\n");

        Console.Write("Enter your choice: ");

        switch (Console.ReadLine())
        {
            case "1": CreateBill(); break;
            case "2": ViewLastBill(); break;
            case "3": LoadFromFile(); break;
            case "4": ViewAllBills(); break;
            case "5": Environment.Exit(0); break;
            default:
                Console.WriteLine("Invalid choice!");
                Pause();
                break;
        }
    }

    private void CreateBill()
    {
        participants.Clear();
        Console.Clear();

        Console.Write("Enter Total Bill: ");
        totalBill = decimal.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter Number of Participants: ");
        int count = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("1. Absolute\n2. Percentage");
        mode = int.Parse(Console.ReadLine() ?? "1");

        bool valid = false;

        while (!valid)
        {
            participants.Clear();
            decimal totalPaid = 0;
            decimal totalPercent = 0;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nParticipant {i + 1}");

                Console.Write("Name: ");
                string name = Console.ReadLine() ?? "";

                if (mode == 1)
                {
                    Console.Write("Amount: ");
                    decimal paid = decimal.Parse(Console.ReadLine() ?? "0");
                    totalPaid += paid;

                    participants.Add(new Participant { Name = name, Paid = paid });
                }
                else
                {
                    Console.Write("Percentage: ");
                    decimal percent = decimal.Parse(Console.ReadLine() ?? "0");
                    totalPercent += percent;

                    decimal paid = (percent / 100) * totalBill;

                    participants.Add(new Participant { Name = name, Paid = paid });
                }
            }

            if (mode == 1 && Math.Abs(totalPaid - totalBill) > 0.01m)
                Console.WriteLine("Error: total mismatch!");
            else if (mode == 2 && Math.Abs(totalPercent - 100) > 0.01m)
                Console.WriteLine("Error: percentage must be 100%");
            else
                valid = true;

            if (!valid)
            {
                Console.WriteLine("Try again...");
                Console.ReadKey();
            }
        }

        hasData = true;
        SaveToFile();
        ShowSummary();
    }

    private void SaveToFile()
    {
        int billNumber = 1;

        if (File.Exists(filePath))
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                if (line.StartsWith("Bill #"))
                    billNumber++;
            }
        }

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine("==========");
            writer.WriteLine($"Bill #{billNumber}");
            writer.WriteLine($"Total:{totalBill}");
            writer.WriteLine($"Mode:{mode}");
            writer.WriteLine($"Count:{participants.Count}");

            foreach (var p in participants)
            {
                writer.WriteLine($"{p.Name}|{p.Paid}");
            }
        }
    }

    private void LoadFromFile()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No file!");
            Pause();
            return;
        }

        var lines = File.ReadAllLines(filePath);

        int start = -1;

        for (int i = lines.Length - 1; i >= 0; i--)
        {
            if (lines[i].StartsWith("Bill #"))
            {
                start = i;
                break;
            }
        }

        if (start == -1)
        {
            Console.WriteLine("No data!");
            Pause();
            return;
        }

        participants.Clear();

        totalBill = decimal.Parse(lines[start + 1].Split(':')[1]);
        mode = int.Parse(lines[start + 2].Split(':')[1]);
        int count = int.Parse(lines[start + 3].Split(':')[1]);

        for (int i = 0; i < count; i++)
        {
            var parts = lines[start + 4 + i].Split('|');

            participants.Add(new Participant
            {
                Name = parts[0],
                Paid = decimal.Parse(parts[1])
            });
        }

        hasData = true;
        Console.WriteLine("Loaded!");
        Pause();
    }

    private void ViewAllBills()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No history!");
            Pause();
            return;
        }

        Console.Clear();
        Console.WriteLine(File.ReadAllText(filePath));
        Console.ReadKey();
    }

    private void ViewLastBill()
    {
        if (!hasData)
        {
            Console.WriteLine("No data!");
            Pause();
            return;
        }

        ShowSummary();
    }

    private void ShowSummary()
    {
        Console.Clear();

        Console.WriteLine($"Total: {totalBill}");
        Console.WriteLine($"Mode: {(mode == 1 ? "Absolute" : "Percentage")}");

        if (mode == 1)
        {
            decimal share = totalBill / participants.Count;

            foreach (var p in participants)
            {
                decimal diff = p.Paid - share;

                if (diff > 0)
                    Console.WriteLine($"{p.Name} gets {diff}");
                else if (diff < 0)
                    Console.WriteLine($"{p.Name} pays {-diff}");
                else
                    Console.WriteLine($"{p.Name} settled");
            }
        }
        else
        {
            foreach (var p in participants)
            {
                Console.WriteLine($"{p.Name} share {p.Paid}");
            }
        }

        Console.ReadKey();
    }

    private void Pause()
    {
        Console.WriteLine("\nPress key...");
        Console.ReadKey();
    }
}

class Program
{
    static void Main()
    {
        new SplitLy().Start();
    }
}
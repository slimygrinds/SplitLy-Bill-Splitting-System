private void CreateBill()
{
    participants.Clear();
    Console.Clear();

    Console.WriteLine("=================================================");
    Console.WriteLine("              CREATE NEW BILL");
    Console.WriteLine("=================================================\n");

     Console.Write("Enter Total Bill Amount: ₹");
    totalBill = decimal.Parse(Console.ReadLine());

    Console.Write("\nEnter Number of Participants: ");
    int count = int.Parse(Console.ReadLine());

    Console.WriteLine("\n-------------------------------------------------");
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();

    Console.Clear();

    Console.WriteLine("=================================================");
    Console.WriteLine("              PARTICIPANT DETAILS");
    Console.WriteLine("=================================================\n");

     for (int i = 0; i < count; i++)
    {
        Console.WriteLine($"Participant {i + 1}");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Amount Paid: ₹");
        decimal paid = decimal.Parse(Console.ReadLine());

        participants.Add(new Participant
        {
            Name = name,
            Paid = paid
        });

        Console.WriteLine("\n---------------------------------------------\n");
    }

    hasData = true;

    ShowSummary();
}
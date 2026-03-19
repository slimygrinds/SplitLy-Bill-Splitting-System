private void EnterParticipants(int count)
    {
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

            participants.Add(new Participant { Name = name, Paid = paid });

            Console.WriteLine("\n---------------------------------------------\n");
        }

        ShowSummary();
    }
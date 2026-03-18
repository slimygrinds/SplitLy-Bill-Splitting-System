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
        }

    }
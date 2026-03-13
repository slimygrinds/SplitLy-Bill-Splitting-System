private void DisplayMenu()
{
    Console.WriteLine("=================================================");
    Console.WriteLine("                    SPLITLY");
    Console.WriteLine("            Bill Splitting System");
    Console.WriteLine("=================================================\n");

    Console.WriteLine("1. Create New Bill");
    Console.WriteLine("2. View Last Settlement");
    Console.WriteLine("3. Exit\n");

    Console.WriteLine("-------------------------------------------------");
}

private string GetUserChoice()
{
    Console.Write("Enter your choice: ");
    return Console.ReadLine();
}

private void HandleMenuChoice(string choice)
{
    switch (choice)
    {
        case "1":
            CreateBill();
            break;

        case "2":
            ViewLastBill();
            break;

        case "3":
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("\nInvalid choice!");
            Pause();
            break;
    }
}
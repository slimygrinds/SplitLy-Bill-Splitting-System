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
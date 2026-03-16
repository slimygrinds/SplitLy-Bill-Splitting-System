private void ShowCreateBillUI()
{
    Console.WriteLine("=================================================");
    Console.WriteLine("                CREATE NEW BILL");
    Console.WriteLine("=================================================\n");

    Console.Write("Enter Total Bill Amount: ₹");
    totalBill = decimal.Parse(Console.ReadLine());

    Console.Write("\nEnter Number of Participants: ");
    tempCount = int.Parse(Console.ReadLine()); 

    Console.WriteLine("\n-------------------------------------------------");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        EnterParticipants(count);
    
}
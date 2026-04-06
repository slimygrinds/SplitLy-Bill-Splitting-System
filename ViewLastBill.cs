using System;

public class ViewLastBill
{
    public void Show()
    {
        Console.Clear();

        Console.WriteLine("=================================================");
        Console.WriteLine("            LAST SETTLEMENT");
        Console.WriteLine("=================================================\n");

        Console.WriteLine("No previous bill saved yet.");

        Console.WriteLine("\n-------------------------------------------------");
        Console.WriteLine("Press any key to return...");
        Console.ReadKey();
    }
}
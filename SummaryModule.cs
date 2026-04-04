using System;
using System.Collections.Generic;

public class SummaryModule
{
    public void ShowSummary(List<Participant> participants, decimal totalBill)
    {
        Console.Clear();

        Console.WriteLine("=================================================");
        Console.WriteLine("             SETTLEMENT SUMMARY");
        Console.WriteLine("=================================================\n");

        decimal equalShare = totalBill / participants.Count;

        Console.WriteLine($"Total Bill Amount      : ₹{totalBill}");
        Console.WriteLine($"Equal Share Per Person : ₹{equalShare}\n");

        Console.WriteLine("-------------------------------------------------");

        foreach (var p in participants)
        {
            decimal diff = p.Paid - equalShare;

            if (diff > 0)
                Console.WriteLine($"{p.Name} -> Should Receive ₹{diff}");
            else if (diff < 0)
                Console.WriteLine($"{p.Name} -> Should Pay ₹{-diff}");
            else
                Console.WriteLine($"{p.Name} -> Settled");
        }

        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }
}
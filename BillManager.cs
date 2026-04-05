using System.Collections.Generic;

public class BillManager
{
    public List<Participant> participants = new List<Participant>();
    public decimal totalBill = 0;

    private SummaryModule summary = new SummaryModule();

    public void ShowSummary()
    {
        summary.ShowSummary(participants, totalBill);
    }
}
namespace ExpenseTracker.Core.Models;

public class Expense
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;

    public override string ToString()
    {
        return $"{Date.ToShortDateString()} - Name: {Name} | Category: {Category} | Amount: {Amount:C} ({Description})";
    }
}
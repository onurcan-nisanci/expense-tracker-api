namespace ExpenseTracker.Models;

public class Savings
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public DateTime CreatedAt { get; set; }
}
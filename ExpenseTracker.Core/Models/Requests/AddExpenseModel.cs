namespace ExpenseTracker.Core.Models.Requests;

public class AddExpenseModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
}
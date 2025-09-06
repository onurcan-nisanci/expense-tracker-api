namespace ExpenseTracker.Models.Requests;

public class AddExpenseModel
{
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
}
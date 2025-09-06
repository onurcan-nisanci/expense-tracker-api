namespace ExpenseTracker.Models;

public class Budget
{
    public decimal MonthlyLimit { get; set; }
    public bool IsOverLimit(decimal monthlyTotal)
    {
        return monthlyTotal > MonthlyLimit;
    }
}
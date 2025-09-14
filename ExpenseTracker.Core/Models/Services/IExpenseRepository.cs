namespace ExpenseTracker.Core.Models.Services;

public interface IExpenseRepository : IRepository<Expense>
{
    Task<List<Expense>> GetByCategoryAsync(string category);
    Task<decimal> GetMonthlyTotal(int year, int month);
    Task<int> DeleteAllByNameAsync(string name);
}
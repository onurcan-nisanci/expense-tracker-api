using ExpenseTracker.Core.Models;

namespace ExpenseTracker.Models.Services;

public interface IExpenseManager
{
    void AddExpense(Expense model);
    void RemoveExpense(Guid Id);
    void RemoveExpenseByName(string name);
    List<Expense> GetExpensesByCategory(string category);
    decimal GetMonthlyTotal(int year, int month);
    List<Expense> GetAllExpenses();
}
using ExpenseTracker.Models;
using ExpenseTracker.Models.Requests;

namespace ExpenseTracker.Services;

public interface IExpenseManager
{
    void AddExpense(AddExpenseModel model);
    void RemoveExpenseByName(string name);
    List<Expense> GetExpensesByCategory(string category);
    decimal GetMonthlyTotal(int year, int month);
    List<Expense> GetAllExpenses();
}
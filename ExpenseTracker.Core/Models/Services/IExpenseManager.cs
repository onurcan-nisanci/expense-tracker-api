using ExpenseTracker.Core.Models;
using ExpenseTracker.Core.Models.Requests;

namespace ExpenseTracker.Models.Services;

public interface IExpenseManager
{
    void AddExpense(AddExpenseModel model);
    void RemoveExpense(Guid Id);
    void RemoveExpenseByName(string name);
    List<Expense> GetExpensesByCategory(string category);
    decimal GetMonthlyTotal(int year, int month);
    List<Expense> GetAllExpenses();
}
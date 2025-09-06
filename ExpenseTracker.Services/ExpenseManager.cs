using ExpenseTracker.Models;
using ExpenseTracker.Models.Requests;

namespace ExpenseTracker.Services;

public class ExpenseManager : IExpenseManager
{
    private readonly List<Expense> _expenses;
    private readonly IStorageService<Expense> _storageService;

    public ExpenseManager(IStorageService<Expense> storageService)
    {
        _storageService = storageService;
        _expenses = _storageService.Load();
    }

    public void AddExpense(AddExpenseModel model)
    {
        var newExpense = new Expense()
        {
            Name = model.Name,
            Amount = model.Amount,
            Category = model.Category,
            Description = model.Description,
            Date = DateTime.Now,
            Id = Guid.NewGuid()
        };

        _expenses.Add(newExpense);
        _storageService.Save(_expenses);
    }

    public void RemoveExpenseByName(string name)
    {
        _expenses.RemoveAll(e => e.Name == name);
        _storageService.Save(_expenses);
    }

    public List<Expense> GetExpensesByCategory(string category)
    {
        throw new NotImplementedException();
    }

    public decimal GetMonthlyTotal(int year, int month)
    {
        throw new NotImplementedException();
    }

    public List<Expense> GetAllExpenses() => _expenses;
}

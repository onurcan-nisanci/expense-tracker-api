using ExpenseTracker.Models;
using ExpenseTracker.Models.Requests;
using ExpenseTracker.Models.Services;

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
            Id = model.Id
        };

        _expenses.Add(newExpense);
        _storageService.Save(_expenses);
    }

    public void RemoveExpense(Guid id)
    {
        _expenses.RemoveAll(e => e.Id == id);
        _storageService.Save(_expenses);
    }

    public void RemoveExpenseByName(string name)
    {
        _expenses.RemoveAll(e => e.Name == name);
        _storageService.Save(_expenses);
    }

    public List<Expense> GetExpensesByCategory(string category)
    {
        return _expenses.Where(c => c.Category.ToLower() == category.ToLower()).ToList();
    }

    public decimal GetMonthlyTotal(int year, int month)
    {
        return _expenses.Where(e => e.Date.Year == year && e.Date.Month == month)
                        .Select(e => e.Amount)
                        .Sum();
    }

    public Expense GetLatestExpense() => _expenses.Last();
    public List<Expense> GetAllExpenses() => _expenses;
}

using ExpenseTracker.Models;
using ExpenseTracker.Models.Services;

namespace ExpenseTracker.Tests;

public class FakeStorageService : IStorageService<Expense>
{
    private List<Expense> _store = new List<Expense>();

    public void Save(List<Expense> expenses)
    {
        _store = new List<Expense>(expenses);
    }

    public List<Expense> Load()
    {
        return new List<Expense>(_store);
    }
}
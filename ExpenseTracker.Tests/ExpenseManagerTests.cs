using ExpenseTracker.Core.Models;
using ExpenseTracker.Services;

namespace ExpenseTracker.Tests;

public class ExpenseManagerTests
{
    private readonly ExpenseManager _manager;

    public ExpenseManagerTests()
    {
        _manager = new ExpenseManager(new FakeStorageService());
    }

    [Fact]
    public void AddExpense_ShouldIncreaseCount()
    {
        var expense = new Expense { Amount = 50, Category = "Food", Description = "Lunch" };

        _manager.AddExpense(expense);

        Assert.Single(_manager.GetAllExpenses());
    }

    [Fact]
    public void RemoveExpense_ShouldRemoveCorrectExpense()
    {
        var expense = new Expense { Amount = 100, Category = "Travel", Description = "Taxi" };
        _manager.AddExpense(expense);

        var latestExpense = _manager.GetLatestExpense();

        _manager.RemoveExpense(latestExpense.Id);

        Assert.Empty(_manager.GetAllExpenses());
    }

    [Fact]
    public void GetExpensesByCategory_ShouldReturnFilteredExpenses()
    {
        _manager.AddExpense(new Expense { Amount = 20, Category = "Food" });
        _manager.AddExpense(new Expense { Amount = 40, Category = "Travel" });

        var foodExpenses = _manager.GetExpensesByCategory("Food");

        Assert.Single(foodExpenses);
        Assert.Equal("Food", foodExpenses.First().Category);
    }

    [Fact]
    public void GetMonthlyTotal_ShouldReturnCorrectSum()
    {
        _manager.AddExpense(new Expense { Amount = 30, Category = "Food" });
        _manager.AddExpense(new Expense { Amount = 70, Category = "Food" });

        decimal total = _manager.GetMonthlyTotal(DateTime.Now.Year, DateTime.Now.Month);

        Assert.Equal(100, total);
    }
}
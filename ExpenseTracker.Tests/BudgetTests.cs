using ExpenseTracker.Core.Models;

namespace ExpenseTracker.Tests;

public class BudgetTests
{
    [Fact]
    public void IsOverLimit_ShouldReturnTrue_WhenTotalExceedsLimit()
    {
        var budget = new Budget { MonthlyLimit = 100m };

        bool result = budget.IsOverLimit(150m);

        Assert.True(result);
    }

    [Fact]
    public void IsOverLimit_ShouldReturnFalse_WhenTotalIsWithinLimit()
    {
        var budget = new Budget { MonthlyLimit = 200m };

        bool result = budget.IsOverLimit(150m);

        Assert.False(result);
    }
}
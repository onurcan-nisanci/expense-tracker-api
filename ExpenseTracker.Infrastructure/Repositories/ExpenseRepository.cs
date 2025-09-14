using ExpenseTracker.Core.Models;
using ExpenseTracker.Core.Models.Services;
using ExpenseTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories;

public class ExpenseRepository : EfRepository<Expense>, IExpenseRepository
{
    private readonly ExpenseTrackerDbContext _db;

    public ExpenseRepository(ExpenseTrackerDbContext db) : base(db)
    {
        _db = db;
    }

    public async Task<List<Expense>> GetByCategoryAsync(string category)
    {
       return await _db.Expenses.Where(e => e.Category.ToLower() == category.ToLower())
                                .ToListAsync();
    }

    public async Task<decimal> GetMonthlyTotal(int year, int month)
    {
        return await _db.Expenses.Where(e => e.Date.Year == year && e.Date.Month == month)
                        .Select(e => e.Amount)
                        .SumAsync();
    }

    public async Task<int> DeleteAllByNameAsync(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return 0;
        }

        var entities = await _db.Expenses
            .Where(e => e.Name.ToLower() == name.ToLower())
            .ToListAsync();

        if (!entities.Any())
        {
            return 0;
        }

        _db.Expenses.RemoveRange(entities);
        return await _db.SaveChangesAsync();
    }
}
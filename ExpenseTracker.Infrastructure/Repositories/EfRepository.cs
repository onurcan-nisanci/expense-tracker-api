using ExpenseTracker.Core.Models.Services;
using ExpenseTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories;

public class EfRepository<T> : IRepository<T> where T : class
{
    private readonly ExpenseTrackerDbContext _db;

    public EfRepository(ExpenseTrackerDbContext db)
    {
        _db = db;
    }

    public async Task<List<T>> GetAllAsync() => await _db.Set<T>().ToListAsync();

    public async Task<T?> GetByIdAsync(Guid id) => await _db.Set<T>().FindAsync(id);

    public async Task AddAsync(T entity)
    {
        _db.Set<T>().Add(entity);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _db.Set<T>().Update(entity);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is not null)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}
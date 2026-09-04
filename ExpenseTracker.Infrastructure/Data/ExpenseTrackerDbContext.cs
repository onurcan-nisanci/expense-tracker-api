using ExpenseTracker.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Data;

public class ExpenseTrackerDbContext : IdentityDbContext<ApplicationUser>
{
    public ExpenseTrackerDbContext(DbContextOptions<ExpenseTrackerDbContext> options)
        : base(options) { }

    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Amount).IsRequired();
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).IsRequired();
            entity.HasIndex(c => c.Name).IsUnique();

            entity.HasData(
                new Category { Id = 1, Name = "Food" },
                new Category { Id = 2, Name = "Groceries" },
                new Category { Id = 3, Name = "Transport" },
                new Category { Id = 4, Name = "Bills" },
                new Category { Id = 5, Name = "Entertainment" },
                new Category { Id = 6, Name = "Health" },
                new Category { Id = 7, Name = "Shopping" },
                new Category { Id = 8, Name = "Other" }
            );
        });
    }
}
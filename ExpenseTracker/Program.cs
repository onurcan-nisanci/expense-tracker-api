
using ExpenseTracker.Core.Models.Services;
using ExpenseTracker.Core.Models;
using ExpenseTracker.Infrastructure.Data;
using ExpenseTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var basePath = AppContext.BaseDirectory;
var dbPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\..\ExpenseTracker.Infrastructure\Data\expense-tracker.db"));

var connectionString = $"Data Source={dbPath}";
var services = new ServiceCollection();

services.AddDbContext<ExpenseTrackerDbContext>(options =>
                                               options.UseSqlite(connectionString));

// Add DI
services.AddScoped<IExpenseRepository, ExpenseRepository>();

var provider = services.BuildServiceProvider();
var expenseRepo = provider.GetRequiredService<IExpenseRepository>();
var budget = new Budget() { MonthlyLimit = 1000 };

while (true)
{
    Console.WriteLine("\n=== Expense Tracker ===");
    Console.WriteLine("1. Add Expense");
    Console.WriteLine("2. Delete All Expense By Name");
    Console.WriteLine("3. View All Expenses");
    Console.WriteLine("4. View Expenses by Category");
    Console.WriteLine("5. Monthly Summary");
    Console.WriteLine("6. Exit");
    Console.Write("Choose: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Amount: ");
            var amount = decimal.Parse(Console.ReadLine());
            Console.Write("Category: ");
            var category = Console.ReadLine();
            Console.Write("Description: ");
            var desc = Console.ReadLine();

            var newExpense = new Expense()
            {
                Name = name,
                Amount = amount,
                Category = category,
                Description = desc,
                Date = DateTime.Now
            };

            await expenseRepo.AddAsync(newExpense);
            Console.WriteLine("Expense added!");
            break;

        case "2":
            Console.Write("Name: ");
            var expenseName = Console.ReadLine() ?? string.Empty;
            var deleteResult = await expenseRepo.DeleteAllByNameAsync(expenseName);

            if (deleteResult > 0)
            {
                Console.WriteLine("Expenses are deleted!");
            } else
            {
                Console.WriteLine("Expenses couldn't found.");
            }
            break;

        case "3":
            foreach (var exp in await expenseRepo.GetAllAsync())
                Console.WriteLine(exp);
            break;

        case "4":
            Console.Write("Enter category: ");
            var cat = Console.ReadLine();
            var filtered = await expenseRepo.GetByCategoryAsync(cat);
            foreach (var exp in filtered) Console.WriteLine(exp);
            break;

        case "5":
            var total = await expenseRepo.GetMonthlyTotal(DateTime.Now.Year, DateTime.Now.Month);
            Console.WriteLine($"This month's total: {total:C}");
            Console.WriteLine(budget.IsOverLimit(total) ? "Over budget!" : "Within budget.");
            break;

        case "6":
            return;
    }
}
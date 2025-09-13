
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
services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

var provider = services.BuildServiceProvider();
var expenseRepo = provider.GetRequiredService<IRepository<Expense>>();

Console.WriteLine("Fetching existing expenses...");

var expenses = await expenseRepo.GetAllAsync();
foreach (var exp in expenses)
{
    Console.WriteLine($"{exp.Id}: {exp.Description} - {exp.Amount:C}");
}

//while (true)
//{
//    Console.WriteLine("\n=== Expense Tracker ===");
//    Console.WriteLine("1. Add Expense");
//    Console.WriteLine("2. View All Expenses");
//    Console.WriteLine("3. View Expenses by Category");
//    Console.WriteLine("4. Monthly Summary");
//    Console.WriteLine("5. Exit");
//    Console.Write("Choose: ");
//    var choice = Console.ReadLine();

//    switch (choice)
//    {
//        case "1":
//            Console.Write("Name: ");
//            var name = Console.ReadLine();
//            Console.Write("Amount: ");
//            var amount = decimal.Parse(Console.ReadLine());
//            Console.Write("Category: ");
//            var category = Console.ReadLine();
//            Console.Write("Description: ");
//            var desc = Console.ReadLine();

//            var addExpenseModel = new AddExpenseModel()
//            {
//                Name = name,
//                Amount = amount,
//                Category = category,
//                Description = desc
//            };

//            expenseManager.AddExpense(addExpenseModel);
//            Console.WriteLine("Expense added!");
//            break;

//        case "2":
//            foreach (var exp in expenseManager.GetAllExpenses())
//                Console.WriteLine(exp);
//            break;

//        case "3":
//            Console.Write("Enter category: ");
//            var cat = Console.ReadLine();
//            var filtered = expenseManager.GetExpensesByCategory(cat);
//            foreach (var exp in filtered) Console.WriteLine(exp);
//            break;

//        case "4":
//            var total = expenseManager.GetMonthlyTotal(DateTime.Now.Year, DateTime.Now.Month);
//            Console.WriteLine($"This month's total: {total:C}");
//            Console.WriteLine(budget.IsOverLimit(total) ? "Over budget!" : "Within budget.");
//            break;

//        case "5":
//            return;
//    }
//}
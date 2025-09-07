
using ExpenseTracker.Models;
using ExpenseTracker.Models.Requests;
using ExpenseTracker.Services;

var expenseStorageService = new JsonStorageService<Expense>("expense.json");
var expenseManager = new ExpenseManager(expenseStorageService);
var budget = new Budget() { MonthlyLimit = 1000m };

while (true)
{
    Console.WriteLine("\n=== Expense Tracker ===");
    Console.WriteLine("1. Add Expense");
    Console.WriteLine("2. View All Expenses");
    Console.WriteLine("3. View Expenses by Category");
    Console.WriteLine("4. Monthly Summary");
    Console.WriteLine("5. Exit");
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

            var addExpenseModel = new AddExpenseModel()
            {
                Name = name,
                Amount = amount,
                Category = category,
                Description = desc
            };

            expenseManager.AddExpense(addExpenseModel);
            Console.WriteLine("Expense added!");
            break;

        case "2":
            foreach (var exp in expenseManager.GetAllExpenses())
                Console.WriteLine(exp);
            break;

        case "3":
            Console.Write("Enter category: ");
            var cat = Console.ReadLine();
            var filtered = expenseManager.GetExpensesByCategory(cat);
            foreach (var exp in filtered) Console.WriteLine(exp);
            break;

        case "4":
            var total = expenseManager.GetMonthlyTotal(DateTime.Now.Year, DateTime.Now.Month);
            Console.WriteLine($"This month's total: {total:C}");
            Console.WriteLine(budget.IsOverLimit(total) ? "Over budget!" : "Within budget.");
            break;

        case "5":
            return;
    }
}
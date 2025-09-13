using ExpenseTracker.Core.Models;
using ExpenseTracker.Core.Models.Requests;
using ExpenseTracker.Services;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:5000", "https://localhost:5001");

var app = builder.Build();

// TODO ON: replace with EF Core later
var manager = new ExpenseManager(new JsonStorageService<Expense>("expense.json"));
var budget = new Budget { MonthlyLimit = 1000m };

app.MapGet("/expenses", () => manager.GetAllExpenses());
app.MapGet("/expenses/category/{category}", (string category) => manager.GetExpensesByCategory(category));
app.MapGet("/expenses/summary/{year}/{month}", (int year, int month) => manager.GetMonthlyTotal(year, month));
app.MapPost("/expenses", (AddExpenseModel expense) =>
{
    manager.AddExpense(expense);
    return Results.Created($"/expenses/{expense.Id}", expense);
});
app.MapDelete("/expenses/{id:guid}", (Guid id) =>
{
    manager.RemoveExpense(id);
    return Results.NoContent();
});

app.Run();
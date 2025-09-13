using ExpenseTracker.Core.Models.Services;
using ExpenseTracker.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly IRepository<Expense> _expenseRepo;

    public ExpensesController(IRepository<Expense> expenseRepo)
    {
        _expenseRepo = expenseRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var expenses = await _expenseRepo.GetAllAsync();
        return Ok(expenses);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Expense expense)
    {
        await _expenseRepo.AddAsync(expense);
        return Ok(expense);
    }
}
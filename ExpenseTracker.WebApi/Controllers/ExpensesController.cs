using ExpenseTracker.Core.Models;
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Core.Models.Services;

namespace ExpenseTracker.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly IExpenseRepository _expenseRepo;

    public ExpensesController(IExpenseRepository expenseRepo)
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

    [HttpGet("category/{category}")]
    public async Task<IActionResult> GetByCategory(string category)
    {
        var expenses = await _expenseRepo.GetByCategoryAsync(category);
        return Ok(expenses);
    }
}
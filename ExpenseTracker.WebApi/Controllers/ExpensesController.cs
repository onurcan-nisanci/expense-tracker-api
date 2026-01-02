using ExpenseTracker.Core.Models;
using ExpenseTracker.Core.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var expenses = await _expenseRepo.GetAllAsync();
        return Ok(expenses);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Expense expense)
    {
        await _expenseRepo.AddAsync(expense);
        return Ok(expense);
    }

    [Authorize]
    [HttpGet("category/{category}")]
    public async Task<IActionResult> GetByCategory(string category)
    {
        var expenses = await _expenseRepo.GetByCategoryAsync(category);
        return Ok(expenses);
    }

    [Authorize]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _expenseRepo.DeleteAsync(id);
        return NoContent();
    }
}
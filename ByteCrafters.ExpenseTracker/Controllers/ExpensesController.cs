using ByteCrafters.ExpenseTrackerApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace ByteCrafters.ExpenseTrackerApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private static List<Expense> _expenses = new List<Expense>
    {
        new Expense { Id = 1, Description = "Groceries", Amount = 100.50M, Date = DateTime.Now },
        new Expense { Id = 2, Description = "Fuel", Amount = 50.00M, Date = DateTime.Now }
    };

    // GET: api/expenses
    [HttpGet]
    public ActionResult<IEnumerable<Expense>> GetAll()
    {
        return Ok(_expenses);
    }

    // GET: api/expenses/{id}
    [HttpGet("{id}")]
    public ActionResult<Expense> GetById(int id)
    {
        var expense = _expenses.FirstOrDefault(e => e.Id == id);
        return expense is not null ? Ok(expense) : NotFound();
    }

    // POST: api/expenses
    [HttpPost]
    public ActionResult<Expense> Create(Expense expense)
    {
        expense.Id = _expenses.Count + 1;
        _expenses.Add(expense);
        return CreatedAtAction(nameof(GetById), new { id = expense.Id }, expense);
    }

    // PUT: api/expenses/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, Expense updatedExpense)
    {
        var existingExpense = _expenses.FirstOrDefault(e => e.Id == id);
        if (existingExpense is null)
            return NotFound();

        existingExpense.Description = updatedExpense.Description;
        existingExpense.Amount = updatedExpense.Amount;
        existingExpense.Date = updatedExpense.Date;

        return NoContent();
    }

    // DELETE: api/expenses/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var expense = _expenses.FirstOrDefault(e => e.Id == id);
        if (expense is null)
            return NotFound();

        _expenses.Remove(expense);
        return NoContent();
    }
}
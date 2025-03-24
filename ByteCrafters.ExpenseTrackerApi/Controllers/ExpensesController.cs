using ByteCrafters.ExpenseTrackerApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace ByteCrafters.ExpenseTrackerApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private static List<Expense> _expenses =
    [
        new() { Id = 1, Description = "Groceries", Amount = 100.50M, Date = DateTime.Now },
        new() { Id = 2, Description = "Fuel", Amount = 50.00M, Date = DateTime.Now },
        new() { Id = 3, Description = "Electricity Bill", Amount = 75.30M, Date = DateTime.Now.AddDays(-1) },
        new() { Id = 4, Description = "Internet Bill", Amount = 40.00M, Date = DateTime.Now.AddDays(-2) },
        new() { Id = 5, Description = "Restaurant", Amount = 120.00M, Date = DateTime.Now.AddDays(-3) },
        new() { Id = 6, Description = "Taxi Ride", Amount = 20.00M, Date = DateTime.Now.AddDays(-4) },
        new() { Id = 7, Description = "Movie Tickets", Amount = 30.00M, Date = DateTime.Now.AddDays(-5) },
        new() { Id = 8, Description = "Clothing", Amount = 150.00M, Date = DateTime.Now.AddDays(-6) },
        new() { Id = 9, Description = "Gym Membership", Amount = 45.00M, Date = DateTime.Now.AddDays(-7) },
        new() { Id = 10, Description = "Coffee", Amount = 5.50M, Date = DateTime.Now.AddDays(-8) },
        new() { Id = 11, Description = "Books", Amount = 80.00M, Date = DateTime.Now.AddDays(-9) },
        new() { Id = 12, Description = "Fuel", Amount = 55.00M, Date = DateTime.Now.AddDays(-10) },
        new() { Id = 13, Description = "Laptop Accessories", Amount = 200.00M, Date = DateTime.Now.AddDays(-11) },
        new() { Id = 14, Description = "Mobile Recharge", Amount = 25.00M, Date = DateTime.Now.AddDays(-12) },
        new() { Id = 15, Description = "Gifts", Amount = 100.00M, Date = DateTime.Now.AddDays(-13) },
        new() { Id = 16, Description = "Groceries", Amount = 90.00M, Date = DateTime.Now.AddDays(-14) },
        new() { Id = 17, Description = "Car Wash", Amount = 15.00M, Date = DateTime.Now.AddDays(-15) },
        new() { Id = 18, Description = "Streaming Subscription", Amount = 10.00M, Date = DateTime.Now.AddDays(-16) },
        new() { Id = 19, Description = "Pizza", Amount = 22.50M, Date = DateTime.Now.AddDays(-17) },
        new() { Id = 20, Description = "Home Decor", Amount = 250.00M, Date = DateTime.Now.AddDays(-18) }
    ];

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
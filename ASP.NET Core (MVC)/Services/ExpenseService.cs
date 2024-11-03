using ASP.NET_Core__MVC_.Data;
using ASP.NET_Core__MVC_.Models;
using Microsoft.EntityFrameworkCore;

public class ExpenseService
{
    private readonly ApplicationDbContext _db;

    public ExpenseService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<List<Expense>> GetExpensesWithCategoryAsync()
    {
        return await _db.Expenses
                             .Include(e => e.Category)
                             .ToListAsync();
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await _db.Categories.ToListAsync();
    }

    public async Task AddExpenseAsync(Expense expense)
    {
        _db.Expenses.Add(expense);
        await _db.SaveChangesAsync();
    }

    public async Task<Expense?> GetExpenseByIdAsync(int id)
    {
        return await _db.Expenses
                        .Include(e => e.Category)
                        .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateExpenseAsync(Expense expense)
    {
        _db.Expenses.Update(expense);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteExpenseAsync(Expense expense)
    {
        _db.Expenses.Remove(expense);
        await _db.SaveChangesAsync();
    }
}

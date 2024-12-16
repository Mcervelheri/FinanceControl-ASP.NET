using ASP.NET_Core__MVC_.Data;
using ASP.NET_Core__MVC_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core__MVC_.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpenseService _expenseService;

        public ExpenseController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
        }
        public async Task<IActionResult> Index()
        {
            var expenses = await _expenseService.GetExpensesWithCategoryAsync();

            return View(expenses);
        }
        public async Task<IActionResult> Create()
        {
            var categories = await _expenseService.GetCategoriesAsync();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expense expense)
        {


            if (ModelState.IsValid) 
            { 
                await _expenseService.AddExpenseAsync(expense);

                TempData["SuccesMessage"] = "Registro cadastrado com sucesso!";

                return RedirectToAction("Index");
            }

            var categories = await _expenseService.GetCategoriesAsync();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");

            return View(expense);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var expense = await _expenseService.GetExpenseByIdAsync(id.Value);

            if (expense == null)
            {
                return NotFound();
            }

            var categories = await _expenseService.GetCategoriesAsync();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");

            return View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _expenseService.UpdateExpenseAsync(expense);

                TempData["SuccesMessage"] = "Registro editado com sucesso!";

                return RedirectToAction("Index");
            }

            var categories = await _expenseService.GetCategoriesAsync();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            return View(expense); 
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var expense = await _expenseService.GetExpenseByIdAsync(id.Value);

            if (expense == null)
            {
                return NotFound();
            }

            var categories = await _expenseService.GetCategoriesAsync();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");

            return View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Expense expense)
        {
            if (expense == null)
            {
                return NotFound();
            }

            await _expenseService.DeleteExpenseAsync(expense);

            TempData["SuccesMessage"] = "Registro excluído com sucesso!";

            return RedirectToAction("Index");

        }


    }
}

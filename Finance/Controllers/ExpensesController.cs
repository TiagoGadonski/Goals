using Finance.Data;
using Finance.Models;
using Finance.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Finance.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly FinanceContext _context;

        public ExpensesController(FinanceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, int? categoryId, bool? isPaidThisMonth)
        {
            var expenses = from e in _context.Expenses.Include(e => e.Category)
                           select e;

            if (!string.IsNullOrEmpty(searchString))
            {
                expenses = expenses.Where(e => e.Description.Contains(searchString));
            }

            if (categoryId.HasValue && categoryId.Value != 0)
            {
                expenses = expenses.Where(e => e.CategoryId == categoryId.Value);
            }

            if (isPaidThisMonth.HasValue)
            {
                expenses = expenses.Where(e => e.IsPaidThisMonth == isPaidThisMonth.Value);
            }

            var totalExpenses = await expenses.SumAsync(e => (double)e.Value);

            var viewModel = new ExpenseIndexViewModel
            {
                Expenses = await expenses.ToListAsync(),
                TotalExpenses = (decimal)totalExpenses,
                Categories = new SelectList(await _context.CategoryFinances.ToListAsync(), "Id", "Name"),
                SearchString = searchString,
                SelectedCategoryId = categoryId,
                IsPaidThisMonth = isPaidThisMonth
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsPaid(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense != null)
            {
                expense.IsPaidThisMonth = true;
                expense.LastPaymentDate = DateTime.Now;
                _context.Update(expense);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.CategoryFinances, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Value,Day,PurchaseDate,Installments,CurrentInstallment,Type,CategoryId")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Log errors
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            ViewBag.Categories = new SelectList(_context.CategoryFinances, "Id", "Name", expense.CategoryId);
            return View(expense);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList(_context.CategoryFinances, "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Value,Day,PurchaseDate,Installments,CurrentInstallment,Type,IsPaidThisMonth,LastPaymentDate,CategoryId")] Expense expense)
        {
            if (id != expense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_context.CategoryFinances, "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses
                .Include(e => e.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(int id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }
    }
}

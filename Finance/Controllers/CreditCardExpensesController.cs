using Finance.Data;
using Finance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance.Controllers
{
    public class CreditCardExpensesController : Controller
    {
        private readonly FinanceContext _context;

        public CreditCardExpensesController(FinanceContext context)
        {
            _context = context;
        }

        // GET: CreditCardExpenses
        public async Task<IActionResult> Index()
        {
            var expenses = _context.CreditCardExpenses.Include(e => e.Category).ToListAsync();
            return View(await expenses);
        }

        // GET: CreditCardExpenses/Create
        public IActionResult Create()
        {
            ViewBag.Categories = _context.CategoryFinances.ToList();
            return View();
        }

        // POST: CreditCardExpenses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Value,Installments,CurrentInstallment,PurchaseDate,IsPaid,CategoryId")] CreditCardExpense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _context.CategoryFinances.ToList();
            return View(expense);
        }

        // GET: CreditCardExpenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.CreditCardExpenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            ViewBag.Categories = _context.CategoryFinances.ToList();
            return View(expense);
        }

        // POST: CreditCardExpenses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Value,Installments,CurrentInstallment,PurchaseDate,IsPaid,CategoryId")] CreditCardExpense expense)
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
                    if (!CreditCardExpenseExists(expense.Id))
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
            ViewBag.Categories = _context.CategoryFinances.ToList();
            return View(expense);
        }

        // GET: CreditCardExpenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.CreditCardExpenses
                .Include(e => e.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: CreditCardExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _context.CreditCardExpenses.FindAsync(id);
            if (expense != null)
            {
                _context.CreditCardExpenses.Remove(expense);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditCardExpenseExists(int id)
        {
            return _context.CreditCardExpenses.Any(e => e.Id == id);
        }
    }
}

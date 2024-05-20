using Finance.Data;
using Finance.Models;
using Finance.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance.Controllers
{
    public class TransactionController : Controller
    {
        private readonly FinanceContext _context;

        public TransactionController(FinanceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var transactions = await _context.Transactions.Include(t => t.Category).ToListAsync();
            var incomes = transactions.Where(t => t.Type == TransactionType.Income).ToList();
            var expenses = transactions.Where(t => t.Type == TransactionType.Expense).ToList();

            var viewModel = new TransactionViewModel
            {
                Incomes = incomes,
                Expenses = expenses
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = _context.CategoryFinances.ToList();
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewBag.Categories = _context.CategoryFinances.ToList();
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Value,Day,Type,CategoryId")] Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.Id))
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
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFinancialGoal(FinancialGoal financialGoal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(financialGoal);
                await _context.SaveChangesAsync();

                if (financialGoal.Status == "Paying")
                {
                    var expense = new Transaction
                    {
                        Description = financialGoal.Name,
                        Value = financialGoal.Amount,
                        Day = DateTime.Now.ToString("yyyy-MM-dd"),
                        Type = TransactionType.Expense,
                        CategoryId = financialGoal.CategoryId
                    };

                    _context.Transactions.Add(expense);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = _context.CategoryFinances.ToList();
            return View(financialGoal);
        }
    }
}

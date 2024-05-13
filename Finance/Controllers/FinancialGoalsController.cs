using Finance.Data;
using Finance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance.Controllers
{
    public class FinancialGoalsController : Controller
    {
        private readonly FinanceContext _context;

        public FinancialGoalsController(FinanceContext context)
        {
            _context = context;
        }

        // GET: FinancialGoals
        public async Task<IActionResult> Index()
        {
            return View(await _context.FinancialGoal.ToListAsync());
        }

        // GET: FinancialGoals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financialGoal = await _context.FinancialGoal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (financialGoal == null)
            {
                return NotFound();
            }

            return View(financialGoal);
        }

        // GET: FinancialGoals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FinancialGoals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,Name,CreatedOn,EstimatedCompletion,Parcelas,Description,ParcelaAtual,Check,Status, ")] FinancialGoal financialGoal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(financialGoal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(financialGoal);
        }

        // GET: FinancialGoals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financialGoal = await _context.FinancialGoal.FindAsync(id);
            if (financialGoal == null)
            {
                return NotFound();
            }
            return View(financialGoal);
        }

        // POST: FinancialGoals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,Name,CreatedOn,EstimatedCompletion,Description,Parcelas,ParcelaAtual,Check,Status")] FinancialGoal financialGoal)
        {
            if (id != financialGoal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(financialGoal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinancialGoalExists(financialGoal.Id))
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
            return View(financialGoal);
        }

        // GET: FinancialGoals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financialGoal = await _context.FinancialGoal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (financialGoal == null)
            {
                return NotFound();
            }

            return View(financialGoal);
        }

        // POST: FinancialGoals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var financialGoal = await _context.FinancialGoal.FindAsync(id);
            if (financialGoal != null)
            {
                _context.FinancialGoal.Remove(financialGoal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinancialGoalExists(int id)
        {
            return _context.FinancialGoal.Any(e => e.Id == id);
        }
    }
}

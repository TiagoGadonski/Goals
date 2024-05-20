using Finance.Data;
using Finance.Models;
using Finance.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance.Controllers
{
    public class GoalsController : Controller
    {
        private readonly FinanceContext _context;

        public GoalsController(FinanceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new FinancialDashboardViewModel
            {
                FinancialGoals = await _context.FinancialGoal.Include(f => f.Category).ToListAsync(),
                Transactions = await _context.Transactions.Include(t => t.Category).ToListAsync(),
                Wishes = await _context.Wish.ToListAsync(),
                CreditCardExpenses = await _context.CreditCardExpenses.Include(c => c.Category).ToListAsync()
            };

            return View(viewModel);
        }

        public IActionResult SaveWish(Wish model)
        {
            // Lógica para salvar o Wish
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SaveFinancialGoal(FinancialGoal model)
        {
            // Lógica para salvar o Financial Goal
            return RedirectToAction("Index");
        }
    }
}

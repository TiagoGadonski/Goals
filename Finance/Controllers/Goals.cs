using Finance.Data;
using Finance.Models;
using Finance.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Controllers
{
    public class Goals : Controller
    {
        private readonly FinanceContext _context;

        public Goals(FinanceContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var viewModel = new FinancialDashboardViewModel
            {
                FinancialGoals = _context.FinancialGoal.ToList(),
                Wishes = _context.Wish.ToList()
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

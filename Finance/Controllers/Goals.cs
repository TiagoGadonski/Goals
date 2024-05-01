using Finance.Data;
using Finance.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}

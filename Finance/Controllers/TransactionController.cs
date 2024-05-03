using Finance.Data;
using Finance.Models;
using Finance.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance.Controllers
{
    namespace Finance.Controllers
    {
        public class TransactionController : Controller  // Ensure the class name ends with 'Controller'
        {
            private readonly FinanceContext _context;

            public TransactionController(FinanceContext context)  // Correct the constructor name
            {
                _context = context;
            }

            public IActionResult Index()
            {
                var viewModel = new TransactionViewModel
                {
                    Transactions = _context.Transactions.Include(t => t.Category).ToList(),
                    Categories = _context.TransactionCategories.ToList()
                };

                return View(viewModel);
            }

            [HttpPost]
            public async Task<IActionResult> AddTransaction(Transaction transaction)
            {
                if (ModelState.IsValid)
                {
                    _context.Transactions.Add(transaction);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(transaction);
            }
        }
    }

}

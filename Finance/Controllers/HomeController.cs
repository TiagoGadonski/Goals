using Finance.Data;
using Finance.Models;
using Finance.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly FinanceContext _context;

    public HomeController(ILogger<HomeController> logger, FinanceContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Buscar todas as transações de despesas
        var expenses = await _context.Expenses
            .Where(e => e.Type != ExpenseType.Temporary || e.IsPaidThisMonth)
            .ToListAsync();

        var totalExpenses = expenses.Where(e => e.IsPaidThisMonth).Sum(e => (double)e.Value);

        var viewModel = new HomeViewModel
        {
            Expenses = expenses,
            TotalExpenses = (decimal)totalExpenses
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult PayInstallment(int id)
    {
        var goal = _context.FinancialGoals.Find(id);
        if (goal != null && goal.Status == "Pagando")
        {
            goal.IsPaidThisMonth = true;
            goal.LastPaymentDate = DateTime.Now;
            goal.ParcelaAtual++;
            if (goal.ParcelaAtual >= goal.Parcelas)
            {
                goal.Status = "Paid";
            }
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult PayTransaction(int id)
    {
        var transaction = _context.Transactions.Find(id);
        if (transaction != null && transaction.Type == TransactionType.Expense)
        {
            transaction.IsPaidThisMonth = true;
            transaction.LastPaymentDate = DateTime.Now;
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

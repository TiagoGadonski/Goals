using Finance.Data;
using Finance.Models;
using Finance.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

    public IActionResult Index()
    {
        // Buscar todas as transações de despesas
        var transactions = _context.Transactions
            .Where(t => t.Type == TransactionType.Expense)
            .ToList();

        // Buscar todas as metas financeiras com status "Pagando"
        var payingFinancialGoals = _context.FinancialGoals
            .Where(fg => fg.Status == "Pagando")
            .ToList();

        // Resetar o estado de pagamento a cada mês
        foreach (var transaction in transactions)
        {
            if (transaction.LastPaymentDate.HasValue && transaction.LastPaymentDate.Value.Month != DateTime.Now.Month)
            {
                transaction.IsPaidThisMonth = false;
                _context.SaveChanges();
            }
        }

        foreach (var goal in payingFinancialGoals)
        {
            if (goal.LastPaymentDate.HasValue && goal.LastPaymentDate.Value.Month != DateTime.Now.Month)
            {
                goal.IsPaidThisMonth = false;
                _context.SaveChanges();
            }
        }

        // Calcular o valor total das despesas, incluindo o valor das parcelas das metas financeiras com status "Pagando"
        var totalExpenses = transactions.Sum(t => t.Value) + payingFinancialGoals.Sum(fg => fg.InstallmentValue);

        var viewModel = new FinancialDashboardViewModel
        {
            FinancialGoals = _context.FinancialGoals.ToList(),
            Wishes = _context.Wish.ToList(),
            Transactions = transactions,
            TotalExpenses = totalExpenses
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

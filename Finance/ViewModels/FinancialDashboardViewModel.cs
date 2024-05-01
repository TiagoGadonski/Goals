using Finance.Models;

namespace Finance.ViewModels
{
    public class FinancialDashboardViewModel
    {
        public IEnumerable<FinancialGoal> FinancialGoals { get; set; }
        public IEnumerable<Wish> Wishes { get; set; }
    }
}

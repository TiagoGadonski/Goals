using Finance.Models;

namespace Finance.ViewModels
{
    public class FinancialDashboardViewModel
    {
        public List<Transaction> Transactions { get; set; }
        public List<Wish> Wishes { get; set; }
        public List<FinancialGoal> FinancialGoals { get; set; }
        public List<CreditCardExpense> CreditCardExpenses { get; set; }
        public List<Category> Categories { get; set; }
        public decimal TotalExpenses { get; set; }
        public FinancialDashboardViewModel()
        {
            FinancialGoals = new List<FinancialGoal>();
            Transactions = new List<Transaction>();
            Wishes = new List<Wish>();
            CreditCardExpenses = new List<CreditCardExpense>();
        }
    }
}

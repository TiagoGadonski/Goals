using Finance.Models;

namespace Finance.ViewModels
{
	public class FinancialDashboardViewModel
	{
		public List<FinancialGoal> FinancialGoals { get; set; }
		public List<Wish> Wishes { get; set; }
		public List<Transaction> Transactions { get; set; }
		public decimal TotalExpenses { get; set; }
	}
}

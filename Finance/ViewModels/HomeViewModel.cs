using Finance.Models;

namespace Finance.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Expense> Expenses { get; set; }
        public decimal TotalExpenses { get; set; }
    }
}

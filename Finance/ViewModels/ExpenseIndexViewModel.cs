using Finance.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Finance.ViewModels
{
    public class ExpenseIndexViewModel
    {
        public IEnumerable<Expense> Expenses { get; set; }
        public decimal TotalExpenses { get; set; }
        public SelectList Categories { get; set; }
        public string SearchString { get; set; }
        public int? SelectedCategoryId { get; set; }
        public bool? IsPaidThisMonth { get; set; }
    }
}

using Finance.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Finance.ViewModels
{
    public class TransactionViewModel
    {
        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<SelectListItem> CategoryOptions { get; set; }  // Name this properly to match the usage in your controller and view
    }
}

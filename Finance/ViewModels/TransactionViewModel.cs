using Finance.Models;

namespace Finance.ViewModels
{
    public class TransactionViewModel
    {
        public List<Transaction> Incomes { get; set; }
        public List<Transaction> Expenses { get; set; }
    }
}

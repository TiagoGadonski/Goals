using Finance.Models;

namespace Finance.ViewModels
{
    public class TransactionViewModel
    {

        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<TransactionCategory> Categories { get; set; }

    }
}

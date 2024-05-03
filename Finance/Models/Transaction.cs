namespace Finance.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
        public TransactionCategory Category { get; set; }  // Transaction category
    }

    public enum TransactionType
    {
        Income,
        Expense
    }

    public class TransactionCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TransactionType Type { get; set; }  // Used to filter categories by transaction type
    }

}

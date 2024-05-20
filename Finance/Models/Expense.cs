using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string Day { get; set; } // Para despesas fixas
        public DateTime? PurchaseDate { get; set; } // Para despesas de cartão de crédito
        public int? Installments { get; set; } // Para despesas de cartão de crédito
        public int? CurrentInstallment { get; set; } // Para despesas de cartão de crédito
        public ExpenseType Type { get; set; }
        public bool IsPaidThisMonth { get; set; }
        public DateTime? LastPaymentDate { get; set; }

        [ForeignKey("CategoryFinance")]
        public int CategoryId { get; set; }
        public CategoryFinance Category { get; set; }
    }

    public enum ExpenseType
    {
        Fixed,
        CreditCard,
        Temporary
    }
}


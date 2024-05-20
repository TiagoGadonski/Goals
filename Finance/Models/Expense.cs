using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Value { get; set; }

        [Required]
        public string Day { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public int? Installments { get; set; }

        public int? CurrentInstallment { get; set; }

        [Required]
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

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Models
{
    public class CreditCardExpense
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int Installments { get; set; }
        public int CurrentInstallment { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        [ForeignKey("CategoryFinance")]
        public int CategoryId { get; set; }
        public CategoryFinance Category { get; set; }
        public CreditCardExpense()
        {
            // Inicialização de valores padrão
            Description = "";
            Value = 0m;
            PurchaseDate = DateTime.Now;
            Installments = 0;
            CurrentInstallment = 0;
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Finance.Models
{
    public class FinancialGoal
    {
        [Key]
        public int Id { get; set; } // Chave primária
        public decimal Amount { get; set; } // Valor da meta financeira
        public string Name { get; set; } // Nome da meta
        public DateTime CreatedOn { get; set; } // Data de criação da meta
        public DateTime? EstimatedCompletion { get; set; } // Previsão de término (opcional)
        public string Status { get; set; } // Status da meta (ex: Active, Completed, Cancelled)
        public int Parcelas { get; set; }
        public int ParcelaAtual { get; set; }
        public bool Check { get; set; }
        public string Description { get; set; }
        public decimal InstallmentValue { get; set; }
        public bool IsPaidThisMonth { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public FinancialGoal()
        {
            // Inicialização de valores padrão
            Amount = 0;
            Name = "Nova Meta Financeira";
            CreatedOn = DateTime.Now;
            EstimatedCompletion = null;
            Status = "Active";
        }
    }
}

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

        public FinancialGoal()
        {
            // Inicialização de valores padrão
            Amount = 0m;
            Name = "Nova Meta Financeira";
            CreatedOn = DateTime.Now;
            EstimatedCompletion = null; // sem data de término definida
            Status = "Active"; // assumindo que a meta é ativada por padrão
        }
    }
}

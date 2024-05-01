using System.ComponentModel.DataAnnotations;

namespace Finance.Models
{
    public class Wish
    {
        [Key]
        public int Id { get; set; } // Chave primária
        public string Name { get; set; } // Nome do desejo
        public string Status { get; set; } // Status do desejo (ex: Pending, Fulfilled)
        public DateTime CreationDate { get; set; } // Data de criação do desejo

        public Wish()
        {
            // Inicialização de valores padrão
            Name = "Novo Desejo";
            Status = "Pending"; // assumindo que o desejo é pendente por padrão
            CreationDate = DateTime.Now;
        }
    }
}

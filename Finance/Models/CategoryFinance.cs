using System.ComponentModel.DataAnnotations;

namespace Finance.Models
{
    public class CategoryFinance
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

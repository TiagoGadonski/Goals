using Finance.Models;
using Microsoft.EntityFrameworkCore;

namespace Finance.Data
{
    public class FinanceContext : DbContext
    {
        public FinanceContext(DbContextOptions<FinanceContext> options)
            : base(options)
        {
        }

        public DbSet<Finance.Models.FinancialGoal> FinancialGoal { get; set; } = default!;
        public DbSet<Finance.Models.Wish> Wish { get; set; } = default!;
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<FinancialGoal> FinancialGoals { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}

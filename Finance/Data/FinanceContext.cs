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
        public DbSet<CategoryFinance> CategoryFinances { get; set; }
        public DbSet<CreditCardExpense> CreditCardExpenses { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Adiciona uma categoria padrão
            modelBuilder.Entity<CategoryFinance>().HasData(
                new CategoryFinance { Id = 1, Name = "Uncategorized" }
            );

            // Define CategoryId como 1 para as tabelas existentes
            modelBuilder.Entity<FinancialGoal>().Property(f => f.CategoryId).HasDefaultValue(1);
            modelBuilder.Entity<Transaction>().Property(t => t.CategoryId).HasDefaultValue(1);
            modelBuilder.Entity<CreditCardExpense>().Property(c => c.CategoryId).HasDefaultValue(1);
        }
    }
}

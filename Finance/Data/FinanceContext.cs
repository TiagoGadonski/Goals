using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Finance.Models;

namespace Finance.Data
{
    public class FinanceContext : DbContext
    {
        public FinanceContext (DbContextOptions<FinanceContext> options)
            : base(options)
        {
        }

        public DbSet<Finance.Models.FinancialGoal> FinancialGoal { get; set; } = default!;
        public DbSet<Finance.Models.Wish> Wish { get; set; } = default!;
    }
}

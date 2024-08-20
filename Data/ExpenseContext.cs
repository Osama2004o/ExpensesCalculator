using Expenses.Models;
using Microsoft.EntityFrameworkCore;

namespace Expenses.Data
{
    public class ExpenseContext:DbContext
    {
        public ExpenseContext(DbContextOptions<ExpenseContext> options):base(options)
        {
            
        }
        public DbSet<Expense> Expensess { get; set; }
    }
}

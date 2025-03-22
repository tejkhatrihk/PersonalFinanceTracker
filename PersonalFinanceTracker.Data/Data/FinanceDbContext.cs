using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Data.Models;

namespace PersonalFinanceTracker.Data;
public class FinanceDbContext : DbContext
{

    public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options) { }

    public DbSet<Transaction> Transactions { get; set; }
}
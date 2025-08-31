using Atm.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Atm.Infrastructure.DataBaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}

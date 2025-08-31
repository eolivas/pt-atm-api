using Atm.Domain.Models;
using Atm.Infrastructure.DataBaseContext;
using Atm.Infrastructure.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Atm.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> Add(Transaction transaction)
        {
            transaction.TransactionDate = DateTime.UtcNow;

            _context.Transactions.Add(transaction);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
                    throw new UniqueConstraintException("A transaction with this Id already exists.", ex);

                throw new InfrastructureException("An error occurred while saving transaction to the database.", ex);
            }

            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetByAccountId(int accountId)
        {
            return await _context.Transactions
                .Where(t => t.AccountId == accountId)
                .OrderByDescending(t => t.TransactionDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetByAccountIdAndDateRange(int accountId, DateTime startDate, DateTime endDate)
        {
            return await _context.Transactions
                .Where(t => t.AccountId == accountId && t.TransactionDate >= startDate && t.TransactionDate <= endDate)
                .OrderByDescending(t => t.TransactionDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Transaction?> GetById(int transactionId)
        {
            return await _context.Transactions.FindAsync(transactionId);
        }
    }
}

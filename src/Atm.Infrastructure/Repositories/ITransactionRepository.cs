using Atm.Domain.Models;

namespace Atm.Infrastructure.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction?> GetById(int transactionId);
        Task<IEnumerable<Transaction>> GetByAccountId(int accountId);
        Task<IEnumerable<Transaction>> GetByAccountIdAndDateRange(int accountId, DateTime startDate, DateTime endDate);
        Task<Transaction> Add(Transaction transaction);
        Task<Transfer> AddTransfer(Transfer transfer);
    }
}


using Atm.Domain.Enums;
using Atm.Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace Atm.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> GetBalanceById(int id)
        {
            decimal credit = await _context.Transactions
                .Where(t => t.AccountId == id && t.Type == TransactionType.Credit)
                .SumAsync(t => t.Amount);

            decimal debit = await _context.Transactions
                .Where(t => t.AccountId == id && t.Type == TransactionType.Debit)
                .SumAsync(t => t.Amount);

            return credit - debit;

        }
    }
}

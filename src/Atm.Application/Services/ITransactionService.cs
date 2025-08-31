using Atm.Application.Dtos;
using Atm.Domain.Models;

namespace Atm.Application.Services
{
    public interface ITransactionService
    {
        Task<int> Deposit(DepositDto depositDto);
        Task<int> Withdraw(WithdrawDto withdrawDto);
        Task<int> Transfer(TransferDto transferDto);
        Task<IEnumerable<Transaction>> GetTransactionsByAccountId(int accountId);
        Task<IEnumerable<Transaction>> GetByAccountIdAndDateRange(int accountId, DateTime startDate, DateTime endDate);

    }
}

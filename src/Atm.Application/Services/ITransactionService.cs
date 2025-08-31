using Atm.Application.Dtos;

namespace Atm.Application.Services
{
    public interface ITransactionService
    {
        Task<int> Deposit(DepositDto depositDto);
    }
}

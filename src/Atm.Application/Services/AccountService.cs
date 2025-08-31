
using Atm.Infrastructure.Repositories;

namespace Atm.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<decimal> GetAccountBalance(int accountId)
        {
            return await _accountRepository.GetBalanceById(accountId);
        }

    }
}

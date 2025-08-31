using Atm.Application.Dtos;
using Atm.Domain.Enums;
using Atm.Domain.Exceptions;
using Atm.Domain.Models;
using Atm.Infrastructure.Repositories;

namespace Atm.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        public TransactionService(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        public async Task<int> Deposit(DepositDto depositDto)
        {

            if (depositDto.Amount <= 0)
                throw new InvalidTransactionAmountException(depositDto.Amount);

            Transaction transaction = new Transaction 
            { 
                AccountId = depositDto.AccountId,
                Amount = depositDto.Amount,
                Type = TransactionType.Credit 
            };
            
            _ = await _transactionRepository.Add(transaction);

            if (transaction.Id > 0)
                return transaction.Id;

            throw new Exception("Unable to make a deposit.");
        }

        public async Task<int> Withdraw(WithdrawDto withdrawDto)
        {
            
            decimal accountBalance = await _accountRepository.GetBalanceById(withdrawDto.AccountId);
            if (accountBalance <= 0)
                throw new InvalidAccountBalanceException(accountBalance);

            if (withdrawDto.Amount <= 0 || accountBalance < withdrawDto.Amount)
                throw new InvalidTransactionAmountException(withdrawDto.Amount);

            Transaction transaction = new Transaction
            {
                AccountId = withdrawDto.AccountId,
                Amount = withdrawDto.Amount,
                Type = TransactionType.Debit
            };

            _ = await _transactionRepository.Add(transaction);

            if (transaction.Id > 0)
                return transaction.Id;

            throw new Exception("Unable to make a withdraw.");
        }

        //public async Task<Transaction> Transfer(Transaction transaction)
        //{
        //    transaction.Type = TransactionType.Withdrawal;
        //    return await _transactionRepository.Add(transaction);
        //}

    }
}

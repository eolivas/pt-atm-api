using Atm.Application.Dtos;
using Atm.Domain.Enums;
using Atm.Domain.Models;
using Atm.Infrastructure.Repositories;

namespace Atm.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<int> Deposit(DepositDto depositDto)
        {
            Transaction transaction = new Transaction 
            { 
                AccountId = depositDto.AccountId,
                Amount = depositDto.Amount,
                Type = TransactionType.Deposit 
            };
            
            _ = await _transactionRepository.Add(transaction);

            if (transaction.Id > 0)
                return transaction.Id;

            throw new Exception("Unable to make a deposit");
        }

        //public async Task<Transaction> Withdraw(Transaction transaction)
        //{
        //    transaction.Type = TransactionType.Withdrawal;
        //    return await _transactionRepository.Add(transaction);
        //}

        //public async Task<Transaction> Transfer(Transaction transaction)
        //{
        //    transaction.Type = TransactionType.Withdrawal;
        //    return await _transactionRepository.Add(transaction);
        //}

    }
}

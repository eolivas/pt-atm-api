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

            throw new DomainException("Unable to make a deposit.");
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

            throw new DomainException("Unable to make a withdraw.");
        }

        public async Task<int> Transfer(TransferDto transferDto)
        {
            //Add account validation for same account
            //Add account validation to check existing account

            WithdrawDto withdrawDto = new (transferDto.DebitAccountId, transferDto.Amount);
            int debitTransactionId = await Withdraw(withdrawDto);

            DepositDto depositDto = new (transferDto.CreditAccountId, transferDto.Amount);
            int creditTransactionId = await Deposit(depositDto);

            Transfer transfer = new Transfer
            {
                DebitTransactionId = debitTransactionId,
                CreditTransactionId = creditTransactionId
            };

            _ = await _transactionRepository.AddTransfer(transfer);

            if (transfer.Id > 0)
                return transfer.Id;

            throw new DomainException("Unable to make a transfer.");
        }

    }
}

using Atm.Domain.Enums;

namespace Atm.Application.Dtos
{
    public record class DepositDto(int AccountId, decimal Amount);

    //public record class WithdrawDto(int Id, int AccountId, decimal Amount, DateTime TransactionDate, TransactionType Type = TransactionType.Withdrawal);
    //public record class TransferDto(int Id, int AccountId, decimal Amount, DateTime TransactionDate, TransactionType Type = TransactionType.Transfer);
}

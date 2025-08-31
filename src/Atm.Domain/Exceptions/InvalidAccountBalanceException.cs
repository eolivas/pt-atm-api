
namespace Atm.Domain.Exceptions
{
    public class InvalidAccountBalanceException : DomainException
    {
        public InvalidAccountBalanceException(decimal balance)
        : base($"Invalid account balance {balance}.") { }
    }
}

namespace Atm.Domain.Exceptions
{
    public class InvalidTransactionAmountException : DomainException
    {
        public InvalidTransactionAmountException(decimal amount)
        : base($"Invalid transaction amount {amount}.") { }
    }
}

namespace Atm.Infrastructure.Exceptions
{
    public class InfrastructureException : Exception
    {
        public InfrastructureException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}

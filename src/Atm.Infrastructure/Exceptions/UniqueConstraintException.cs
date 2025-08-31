
namespace Atm.Infrastructure.Exceptions
{
    public class UniqueConstraintException : InfrastructureException
    {
        public UniqueConstraintException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}

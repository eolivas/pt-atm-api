namespace Atm.Infrastructure.Repositories
{
    public interface IAccountRepository
    {
        Task<decimal> GetBalanceById(int id);
    }
}

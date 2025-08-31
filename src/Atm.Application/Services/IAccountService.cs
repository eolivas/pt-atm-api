namespace Atm.Application.Services
{
    public  interface IAccountService
    {
        Task<decimal> GetAccountBalance(int accountId);
    }
}

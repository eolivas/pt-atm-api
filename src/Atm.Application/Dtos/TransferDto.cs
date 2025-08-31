
namespace Atm.Application.Dtos
{
    public record class TransferDto(int DebitAccountId, int CreditAccountId, decimal Amount);
}

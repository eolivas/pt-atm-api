
namespace Atm.Domain.Models
{
    public class Transfer
    {
        public int Id { get; set; }
        public int DebitTransactionId { get; set; }
        public int CreditTransactionId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}

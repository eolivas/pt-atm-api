using Atm.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Atm.Domain.Models
{
    public  class Transaction
    {
        public int Id { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        [Range(0.01, 50000.00)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }


        public TransactionType Type { get; set; }

    }
}

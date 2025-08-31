using Atm.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Atm.Domain.Models
{
    public class Account
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        public AccountType AccountType { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentSystem.SqlRepository.Models
{
    public class Card
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "ClientName is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the ClientName is 50 characters.")]
        public string ClientName { get; set; }

        [ForeignKey(nameof(BankAccount))]
        public Guid BankAccountId { get; set; }

        [Required(ErrorMessage = "CardNumber is a required field.")]
        [MaxLength(16, ErrorMessage = "Maximum length for the CardNumber is 16 characters.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "IssueDate is a required field.")]
        public DateTime IssueDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "Cvc is a required field.")]
        [MaxLength(3, ErrorMessage = "Maximum length for the Cvc is 3 characters.")]
        public ushort Cvc { get; set; }
    }
}

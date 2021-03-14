using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.Contract.Transport
{
    public class CreateTransactionRequest
    {
        [Required]
        [StringLength(16, ErrorMessage = "Card number should consist of 16 characters.")]
        public string SenderCardNumber { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "Card number should consist of 16 characters.")]
        public string RecipientCardId { get; set; }

        [Required]
        public decimal AmountOfMoney { get; set; }
    }
}

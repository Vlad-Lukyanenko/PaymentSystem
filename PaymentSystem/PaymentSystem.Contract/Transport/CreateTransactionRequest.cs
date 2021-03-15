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
        [Range(1, double.MaxValue, ErrorMessage = "Please enter a AmountOfMoney value bigger than {0}")]
        public double AmountOfMoney { get; set; }
    }
}

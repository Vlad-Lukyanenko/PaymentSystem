using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.Contract.Transport
{
    public class GetClientsRequest
    {
        [Required]
        [Range(1, ushort.MaxValue, ErrorMessage = "Please enter a PageNumber value bigger than {0}")]
        public ushort PageNumber { get; set; }

        [Required]
        [Range(1, ushort.MaxValue, ErrorMessage = "Please enter a PerPage value bigger than {0}")]
        public ushort PerPage { get; set; }
    }
}

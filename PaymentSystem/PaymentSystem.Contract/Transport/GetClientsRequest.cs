using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.Contract.Transport
{
    public class GetClientsRequest
    {
        [Required]
        public ushort PageNumber { get; set; }

        [Required]
        public ushort PerPage { get; set; }
    }
}

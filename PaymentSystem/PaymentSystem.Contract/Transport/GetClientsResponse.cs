using PaymentSystem.Contract.Models;
using System.Collections.Generic;

namespace PaymentSystem.Contract.Transport
{
    public class GetClientsResponse
    {
        public IEnumerable<Client> Clients { get; set; }
    }
}

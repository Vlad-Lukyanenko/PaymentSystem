using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Contract.Transport;
using PaymentSystem.Domain;
using PaymentSystem.Infrastructure.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IEnumerable<Client>> Get([FromQuery] GetClientsRequest request)
        {
            return await _clientService.GetClients(request.PageNumber, request.PerPage);
        }
    }
}

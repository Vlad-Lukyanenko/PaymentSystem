using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Contract.Models;
using PaymentSystem.Contract.Transport;
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
        public readonly IMapper _mapper;
        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Client>> Get([FromQuery] GetClientsRequest request)
        {
            var clients = await _clientService.GetClients(request.PageNumber, request.PerPage);

            return _mapper.Map<IEnumerable<Client>>(clients);
        }
    }
}

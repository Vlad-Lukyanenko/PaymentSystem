using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Domain;
using PaymentSystem.Infrastructure.Client;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem.SqlRepository
{
    public class ClientRepository : IClientRepository
    {
        public readonly PaymentSystemContext _dbContext;
        public readonly IMapper _mapper;

        public ClientRepository(PaymentSystemContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(Client client)
        {
            var sqlModel = _mapper.Map<Models.Client>(client);

            await _dbContext.Clients.AddAsync(sqlModel);
        }

        public async Task<IEnumerable<Client>> GetClientsAsync(ushort pageNumber, ushort perPage)
        {
            var clients = await _dbContext.Clients
                .Include(c => c.BankAccounts)
                .ThenInclude(c => c.PaymentCards)
                .Skip((pageNumber - 1) * perPage)
                .Take(perPage)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<Client>>(clients);
        }
    }
}

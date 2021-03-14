using PaymentSystem.Domain;
using PaymentSystem.Infrastructure;
using PaymentSystem.Infrastructure.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentSystem.Application
{
    public class ClientService : IClientService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ClientService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task CreateAsync(Client client)
        {
            await _repositoryManager.Client.CreateAsync(client);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> GetClients(ushort pageNumber, ushort perPage)
        {
            return await _repositoryManager.Client.GetClientsAsync(pageNumber, perPage);
        }
    }
}

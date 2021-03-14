using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentSystem.Infrastructure.Client
{
    public interface IClientService
    {
        Task CreateAsync(Domain.Client client);

        Task<IEnumerable<Domain.Client>> GetClients(ushort pageNumber, ushort perPage);        
    }
}

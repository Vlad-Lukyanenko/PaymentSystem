using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentSystem.Infrastructure.Client
{
    public interface IClientRepository
    {
        Task CreateAsync(Domain.Client client);

        Task<IEnumerable<Domain.Client>> GetClientsAsync(ushort pageNumber, ushort perPage);
    }
}

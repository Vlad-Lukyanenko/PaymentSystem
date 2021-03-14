using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentSystem.Infrastructure.Transaction
{
    public interface ITransactionRepository
    {
        Task CreateAsync(Domain.Transaction transaction);

        Task<IEnumerable<Domain.Transaction>> GetTransactionsAsync(ushort pageNumber, ushort perPage);
    }
}

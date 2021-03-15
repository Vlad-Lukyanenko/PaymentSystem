using PaymentSystem.Infrastructure.Client;
using PaymentSystem.Infrastructure.Transaction;
using System.Threading.Tasks;

namespace PaymentSystem.Infrastructure
{
    public interface IRepositoryManager
    {
        IBankAccountRepository BankAccount { get; }

        IClientRepository Client { get; }

        ITransactionRepository Transaction { get; }

        Task SaveChangesAsync();
    }
}

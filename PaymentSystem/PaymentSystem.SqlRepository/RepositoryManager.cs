using PaymentSystem.Infrastructure;
using PaymentSystem.Infrastructure.Client;
using PaymentSystem.Infrastructure.Transaction;
using System.Threading.Tasks;

namespace PaymentSystem.SqlRepository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly PaymentSystemContext _dbContext;

        public RepositoryManager(
            PaymentSystemContext dbContext,
            IBankAccountRepository bankAccountRepository,
            IClientRepository clientRepository,
            ITransactionRepository transactionRepository)
        {
            _dbContext = dbContext;
            BankAccount = bankAccountRepository;
            Client = clientRepository;
            Transaction = transactionRepository;
        }

        public IBankAccountRepository BankAccount { get; }

        public IClientRepository Client { get; }

        public ITransactionRepository Transaction { get; }

        public Task SaveChangesAsync() => _dbContext.SaveChangesAsync();
    }
}

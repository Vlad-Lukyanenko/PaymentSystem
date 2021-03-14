using PaymentSystem.Infrastructure;
using PaymentSystem.Infrastructure.Client;
using PaymentSystem.Infrastructure.Transaction;
using System.Threading.Tasks;

namespace PaymentSystem.SqlRepository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly PaymentSystemContext _dbContext;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IClientRepository _clientRepository;
        private readonly ITransactionRepository _transactionRepository;

        public RepositoryManager(
            PaymentSystemContext dbContext,
            IBankAccountRepository bankAccountRepository,
            IClientRepository clientRepository,
            ITransactionRepository transactionRepository)
        {
            _dbContext = dbContext;
            _bankAccountRepository = bankAccountRepository;
            _clientRepository = clientRepository;
            _transactionRepository = transactionRepository;
        }

        public IBankAccountRepository BankAccount => _bankAccountRepository;

        public IClientRepository Client => _clientRepository;

        public ITransactionRepository Transaction => _transactionRepository;

        public Task SaveChangesAsync() => _dbContext.SaveChangesAsync();
    }
}

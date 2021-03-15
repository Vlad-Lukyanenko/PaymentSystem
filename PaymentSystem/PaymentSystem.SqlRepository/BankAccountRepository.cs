using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Domain;
using PaymentSystem.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem.SqlRepository
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly PaymentSystemContext _dbContext;
        private readonly IMapper _mapper;

        public BankAccountRepository(PaymentSystemContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    
        public async Task<BankAccount> GetBankAccountByCardNumberAsync(string cardNumber)
        {
            var account = await _dbContext
               .BankAccounts
               .Include(c => c.PaymentCards)
               .SingleOrDefaultAsync(c => c.PaymentCards.Any(x => x.CardNumber.Equals(cardNumber)));

            return _mapper.Map<BankAccount>(account);
        }

        public async Task<BankAccount> PutMoneyIntoAccountAsync(string cardNumber, double amountOfMoney)
        {
            var account = await _dbContext.BankAccounts.Include(c => c.PaymentCards).SingleOrDefaultAsync(c => c.PaymentCards.Any(p => p.CardNumber.Equals(cardNumber)));

            if (account == null)
            {
                return null;
            }

            account.AmountOfMoney += amountOfMoney;

            return _mapper.Map<BankAccount>(account);
        }

        public async Task<BankAccount> GetMoneyFromAccountAsync(string cardNumber, double amountOfMoney)
        {
            var account = await _dbContext.BankAccounts.Include(c => c.PaymentCards).SingleOrDefaultAsync(c => c.PaymentCards.Any(p => p.CardNumber.Equals(cardNumber)));

            if (account == null)
            {
                return null;
            }

            account.AmountOfMoney -= amountOfMoney;

            return _mapper.Map<BankAccount>(account);
        }
    }
}

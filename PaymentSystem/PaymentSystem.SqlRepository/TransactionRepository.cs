using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Domain;
using PaymentSystem.Infrastructure.Transaction;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem.SqlRepository
{
    public class TransactionRepository : ITransactionRepository
    { 
        private readonly PaymentSystemContext _dbContext;
        private readonly IMapper _mapper;

        public TransactionRepository(PaymentSystemContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(Transaction transaction)
        {
            var sqlModel = _mapper.Map<Models.Transaction>(transaction);

            await _dbContext.AddAsync(sqlModel);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync(ushort pageNumber, ushort perPage)
        {
            var clients = await _dbContext.Transactions
                .Skip((pageNumber - 1) * perPage)
                .Take(perPage)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<Transaction>>(clients);
        }
    }
}

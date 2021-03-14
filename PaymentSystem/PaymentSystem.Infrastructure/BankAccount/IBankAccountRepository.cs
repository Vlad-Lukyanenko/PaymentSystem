using PaymentSystem.Domain;
using System.Threading.Tasks;

namespace PaymentSystem.Infrastructure
{
    public interface IBankAccountRepository
    {
        Task<BankAccount> GetBankAccountByCardNumberAsync(string cardNumber);

        Task<BankAccount> PutMoneyIntoAccountAsync(string cardNumber, decimal amountOfMoney);

        Task<BankAccount> GetMoneyFromAccountAsync(string cardNumber, decimal amountOfMoney);
    }
}

using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem.Tests.RepositoryTest
{
    [TestFixture]
    public class BankAccountRepositoryTest : BaseTest
    {
        [Test]
        public async Task CreateAndGetBankAccount_Test()
        {
            var client = DataProvider.GetClients()[0];

            await RepositoryManager.Client.CreateAsync(client);
            await RepositoryManager.SaveChangesAsync();

            var bankAccount = await RepositoryManager.BankAccount.GetBankAccountByCardNumberAsync(client.BankAccounts.ToList()[0].PaymentCards.ToList()[0].CardNumber);

            Assert.IsTrue(bankAccount != null);         
            Assert.AreEqual(client.BankAccounts.ToList()[0].PaymentCards.ToList()[0].CardNumber, bankAccount.PaymentCards.ToList()[0].CardNumber);
        }

        [Test]
        public async Task PutMoneyIntoAccountAsync_Test()
        {
            var client = DataProvider.GetClients()[0];

            await RepositoryManager.Client.CreateAsync(client);
            await RepositoryManager.SaveChangesAsync();

            var oldAmountOfMoneyValue = client.BankAccounts.ToList()[0].AmountOfMoney;
            const int moneyToAdd = 1000;

            await RepositoryManager.BankAccount.PutMoneyIntoAccountAsync(client.BankAccounts.ToList()[0].PaymentCards.ToList()[0].CardNumber, moneyToAdd);
            await RepositoryManager.SaveChangesAsync();

            var bankAccount = await RepositoryManager.BankAccount.GetBankAccountByCardNumberAsync(client.BankAccounts.ToList()[0].PaymentCards.ToList()[0].CardNumber);

            var updatedAmountOfMoneyValue = bankAccount.AmountOfMoney;

            Assert.AreEqual(updatedAmountOfMoneyValue, oldAmountOfMoneyValue + moneyToAdd);
        }

        [Test]
        public async Task GetMoneyFromAccountAsync_Test()
        {
            var client = DataProvider.GetClients()[0];

            await RepositoryManager.Client.CreateAsync(client);
            await RepositoryManager.SaveChangesAsync();

            var oldAmountOfMoneyValue = client.BankAccounts.ToList()[0].AmountOfMoney;
            const int moneyToGet = 1000;

            await RepositoryManager.BankAccount.GetMoneyFromAccountAsync(client.BankAccounts.ToList()[0].PaymentCards.ToList()[0].CardNumber, moneyToGet);
            await RepositoryManager.SaveChangesAsync();

            var bankAccount = await RepositoryManager.BankAccount.GetBankAccountByCardNumberAsync(client.BankAccounts.ToList()[0].PaymentCards.ToList()[0].CardNumber);

            var updatedAmountOfMoneyValue = bankAccount.AmountOfMoney;

            Assert.AreEqual(updatedAmountOfMoneyValue, oldAmountOfMoneyValue - moneyToGet);
        }
    }
}


using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem.Tests.RepositoryTest
{
    [TestFixture]
    public class TransactionServiceTest : BaseTest
    {
        [Test]
        public async Task CreateAndGetTransaction_Test()
        {
            var client = DataProvider.GetClients();

            await RepositoryManager.Client.CreateAsync(client[0]);
            await RepositoryManager.Client.CreateAsync(client[1]);
            await RepositoryManager.SaveChangesAsync();

            var clients = (await RepositoryManager.Client.GetClientsAsync(1, 2)).ToList();

            var amountOfMoney = 100;

            await RepositoryManager.Transaction.CreateAsync(new Domain.Transaction
            {
                Id = Guid.NewGuid(),
                AmountOfMoney = amountOfMoney,
                DateCreated = DateTime.Now,
                SenderCardId = clients[0].BankAccounts.ToList()[0].PaymentCards.ToList()[0].Id,
                RecipientCardId = clients[1].BankAccounts.ToList()[0].PaymentCards.ToList()[0].Id,
            });

            await RepositoryManager.SaveChangesAsync();

            var transactions = await RepositoryManager.Transaction.GetTransactionsAsync(1, 1);

            Assert.IsTrue(transactions != null);
            Assert.IsTrue(transactions.ToList().Count > 0);
            Assert.AreEqual(amountOfMoney, transactions.ToList()[0].AmountOfMoney);
        }
    }
}

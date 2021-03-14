using NUnit.Framework;
using PaymentSystem.Infrastructure.Transaction;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PaymentSystem.Application.CustomExceptions;
using NUnit.Framework.Constraints;
using System.Collections.Generic;

namespace PaymentSystem.Tests.ServiceTest
{
    [TestFixture]
    public class TransactionServiceTest : BaseTest
    {
        [Test]
        public async Task TransferMoneySuccess_Test()
        {
            var transactionService = TestServiceProvider.GetService<ITransactionService>();

            var domainClients = DataProvider.GetClients();

            await RepositoryManager.Client.CreateAsync(domainClients[0]);
            await RepositoryManager.Client.CreateAsync(domainClients[1]);
            await RepositoryManager.SaveChangesAsync();

            var clients = (await RepositoryManager.Client.GetClientsAsync(1, 2)).ToList();

            var amountOfMoney = 100;

            await transactionService.TransferMoneyAsync(
                clients[0].BankAccounts.ToList()[0].PaymentCards.ToList()[0].CardNumber,
                clients[1].BankAccounts.ToList()[0].PaymentCards.ToList()[0].CardNumber,
                amountOfMoney);

            await RepositoryManager.SaveChangesAsync();

            var transactions = await RepositoryManager.Transaction.GetTransactionsAsync(1, 1);

            Assert.IsTrue(transactions != null);
            Assert.IsTrue(transactions.ToList().Count > 0);
            Assert.AreEqual(amountOfMoney, transactions.ToList()[0].AmountOfMoney);
        }

        [Test]
        public async Task TransferMoneyWrongCardFormat_Test()
        {
            var transactionService = TestServiceProvider.GetService<ITransactionService>();

            var domainClients = DataProvider.GetClients();

            domainClients[0].BankAccounts.ToList()[0].PaymentCards.ToList()[0].CardNumber = "123";

            await RepositoryManager.Client.CreateAsync(domainClients[0]);
            await RepositoryManager.Client.CreateAsync(domainClients[1]);
            await RepositoryManager.SaveChangesAsync();

            var clients = (await RepositoryManager.Client.GetClientsAsync(1, 2)).ToList();

            var amountOfMoney = 100;

            var incorrectCardNumber = false;

            try
            {
                await transactionService.TransferMoneyAsync(
                clients[0].BankAccounts.ToList()[0].PaymentCards.ToList()[0].CardNumber,
                clients[1].BankAccounts.ToList()[0].PaymentCards.ToList()[0].CardNumber,
                amountOfMoney);
            }
            catch (InvalidCardNumberException)
            {
                incorrectCardNumber = true;
            }
           
            Assert.AreEqual(true, incorrectCardNumber);
        }

        [Test]
        public async Task TransferMoneyBankAccountNotFound_Test()
        {
            var transactionService = TestServiceProvider.GetService<ITransactionService>();

            var domainClients = DataProvider.GetClients();

            await RepositoryManager.Client.CreateAsync(domainClients[0]);
            await RepositoryManager.Client.CreateAsync(domainClients[1]);
            await RepositoryManager.SaveChangesAsync();

            var clients = (await RepositoryManager.Client.GetClientsAsync(1, 2)).ToList();

            var amountOfMoney = 100;

            var bankAccountNotFound = false;

            try
            {
                await transactionService.TransferMoneyAsync(
                "1111222233334444",
                clients[1].BankAccounts.ToList()[0].PaymentCards.ToList()[0].CardNumber,
                amountOfMoney);
            }
            catch (BankAccountNotFoundException)
            {
                bankAccountNotFound = true;
            }

            Assert.AreEqual(true, bankAccountNotFound);
        }

        [Test]
        public async Task TransferMoneyInsufficientFunds_Test()
        {
            var transactionService = TestServiceProvider.GetService<ITransactionService>();

            var domainClients = DataProvider.GetClients();

            await RepositoryManager.Client.CreateAsync(domainClients[0]);
            await RepositoryManager.Client.CreateAsync(domainClients[1]);
            await RepositoryManager.SaveChangesAsync();

            var clients = (await RepositoryManager.Client.GetClientsAsync(1, 2)).ToList();

            var amountOfMoney = 100000000;

            var insufficientFunds = false;

            try
            {
                await transactionService.TransferMoneyAsync(
                clients[0].BankAccounts.ToList()[0].PaymentCards.ToList()[0].CardNumber,
                clients[1].BankAccounts.ToList()[0].PaymentCards.ToList()[0].CardNumber,
                amountOfMoney);
            }
            catch (InsufficientFundsException)
            {
                insufficientFunds = true;
            }

            Assert.AreEqual(true, insufficientFunds);
        }
    }
}

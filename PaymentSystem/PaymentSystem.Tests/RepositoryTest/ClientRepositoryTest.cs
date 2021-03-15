using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem.Tests.RepositoryTest
{
    [TestFixture]
    public class ClientRepositoryTest : BaseTest
    {
        [Test]
        public async Task CreateAndGetClientAccount_Test()
        {
            var client = DataProvider.GetClients()[0];

            await RepositoryManager.Client.CreateAsync(client);
            await RepositoryManager.SaveChangesAsync();

            var clients = (await RepositoryManager.Client.GetClientsAsync(1, 1)).ToList();

            Assert.IsTrue(clients != null);
            Assert.IsTrue(clients.Count > 0);
            Assert.AreEqual("First Last", $"{clients[0].FirstName} {clients[0].LastName}");
        }
    }
}

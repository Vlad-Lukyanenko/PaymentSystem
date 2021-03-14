using Microsoft.EntityFrameworkCore;
using PaymentSystem.SqlRepository.Models;
using PaymentSystem.SqlRepository.Configuration;

namespace PaymentSystem.SqlRepository
{
    public class PaymentSystemContext : DbContext
    {
        public PaymentSystemContext(DbContextOptions<PaymentSystemContext> options)
           : base(options)
        {
        }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new CardConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

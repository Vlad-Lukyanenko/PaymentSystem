using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PaymentSystem.Application;
using PaymentSystem.Infrastructure;
using PaymentSystem.Infrastructure.Client;
using PaymentSystem.Infrastructure.ConfigSettings;
using PaymentSystem.Infrastructure.Transaction;
using PaymentSystem.SqlRepository;
using System;
using System.ComponentModel.Design;

namespace PaymentSystem.Tests
{
    public abstract class BaseTest
    {
        protected readonly IRepositoryManager RepositoryManager;

        protected BaseTest()
        {
            var services = new ServiceCollection();

            services.AddScoped<IBankAccountRepository, BankAccountRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            
            services.AddDbContext<PaymentSystemContext>(b =>
            {
                b.UseInMemoryDatabase("InMemory");
                Options = (DbContextOptions<PaymentSystemContext>)b.Options;
            });
            services.AddMemoryCache();

            services.AddAutoMapper(
                    typeof(ClientService).Assembly,
                    typeof(TransactionService).Assembly,
                    typeof(PaymentSystemContext).Assembly);

            services.Configure<PaymentCardSettings>(x =>
            {
                x.CardNumberFilter = "^[0-9]{16}$";
            });

            services.AddTransient(typeof(DbContext), typeof(PaymentSystemContext));
            services.AddScoped<IServiceContainer, ServiceContainer>();

            TestServiceProvider = services.BuildServiceProvider();

            RepositoryManager = (IRepositoryManager)TestServiceProvider.GetService(typeof(IRepositoryManager));
        }

        protected DbContextOptions<PaymentSystemContext> Options { get; set; }

        protected IServiceProvider TestServiceProvider { get; set; }

        protected IMapper Mapper { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            TestServiceProvider.GetService<PaymentSystemContext>();
            Mapper = TestServiceProvider.GetService<IMapper>();
        }

        [TearDown]
        public void TearDown()
        {
            var context = TestServiceProvider.GetService<PaymentSystemContext>();
            context.Database.EnsureDeleted();

            #pragma warning disable EF1001 // Internal EF Core API usage.
            context.GetDependencies().StateManager.ResetState();
            #pragma warning restore EF1001 // Internal EF Core API usage.
        }
    }
}
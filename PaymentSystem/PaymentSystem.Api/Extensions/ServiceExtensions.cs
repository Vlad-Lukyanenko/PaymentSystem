using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentSystem.Application;
using PaymentSystem.Infrastructure;
using PaymentSystem.Infrastructure.Client;
using PaymentSystem.Infrastructure.ConfigSettings;
using PaymentSystem.Infrastructure.Transaction;
using PaymentSystem.SqlRepository;

namespace PaymentSystem.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PaymentSystemContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("SqlConnection"), b => b.MigrationsAssembly("PaymentSystem.Api")));
        }

        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBankAccountRepository, BankAccountRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureAppSettings(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<PaymentCardSettings>(config.GetSection("PaymentCardSettings"));
        }
    }
}

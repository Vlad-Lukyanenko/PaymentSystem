using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentSystem.SqlRepository.Models;
using System;

namespace PaymentSystem.SqlRepository.Configuration
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasData
            (
                new BankAccount { Id = Guid.Parse("87AB530A-AA4A-4FCB-A09D-436C03BE080C"), ClientId = Guid.Parse("EF74F0F4-FCCA-4751-A39E-4FAAE75F9123"), AmountOfMoney = 10000 },
                new BankAccount { Id = Guid.Parse("A41713C6-393E-4202-B490-62028BAC8AED"), ClientId = Guid.Parse("16DB1414-387C-40D1-89E3-05945C4661A1"), AmountOfMoney = 20000 },
                new BankAccount { Id = Guid.Parse("56617F02-32FD-4C1A-83CE-341E7AF16A25"), ClientId = Guid.Parse("C5A3B5DC-CAA1-4B00-987B-B3ACF0527397"), AmountOfMoney = 20000 },
                new BankAccount { Id = Guid.Parse("5B5385B9-5157-4D4C-A883-1EA0C2BFF1ED"), ClientId = Guid.Parse("28E1DE8A-715A-4D50-8A08-2D86CACA0BB4"), AmountOfMoney = 30000 },
                new BankAccount { Id = Guid.Parse("54BF5559-3DED-4338-98F5-02D18509E7FD"), ClientId = Guid.Parse("D7FAFCDD-FAF2-472D-9D52-4C9256C77149"), AmountOfMoney = 40000 },
                new BankAccount { Id = Guid.Parse("52EF23AA-621F-4184-B88B-263F5F2E4B0F"), ClientId = Guid.Parse("D7FAFCDD-FAF2-472D-9D52-4C9256C77149"), AmountOfMoney = 50000 },
                new BankAccount { Id = Guid.Parse("2F524819-7B82-404F-B55B-AF16D5FCF98E"), ClientId = Guid.Parse("1D8F8003-FD0E-42B5-9F7E-05B766DE6340"), AmountOfMoney = 60000 }
            );
        }
    }
}
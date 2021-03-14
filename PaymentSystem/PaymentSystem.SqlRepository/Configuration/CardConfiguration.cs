using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentSystem.SqlRepository.Models;
using System;

namespace PaymentSystem.SqlRepository.Configuration
{
    class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasData
            (
                new Card { Id = Guid.Parse("6C24145B-2B66-40B9-8057-A1C6C80E114F"), CardNumber = "1234789565897412", ClientName = "Thor Odinson", Cvc = 123, IssueDate = new DateTime(2021, 01, 01), ExpirationDate = new DateTime(2024, 01, 01), BankAccountId = Guid.Parse("87AB530A-AA4A-4FCB-A09D-436C03BE080C") },
                new Card { Id = Guid.Parse("C85E2B5D-E144-4076-AF2D-9281EC0C6E98"), CardNumber = "5847632589562417", ClientName = "Tony Stark", Cvc = 734, IssueDate = new DateTime(2021, 01, 01), ExpirationDate = new DateTime(2024, 01, 01), BankAccountId = Guid.Parse("A41713C6-393E-4202-B490-62028BAC8AED") },
                new Card { Id = Guid.Parse("19916E12-94C2-48BF-BAA8-DAABC5D43264"), CardNumber = "2569875896325698", ClientName = "Tony Stark", Cvc = 745, IssueDate = new DateTime(2021, 01, 01), ExpirationDate = new DateTime(2024, 01, 01), BankAccountId = Guid.Parse("A41713C6-393E-4202-B490-62028BAC8AED") },
                new Card { Id = Guid.Parse("9ADBAEBC-78E5-4CCA-BE0D-F05871F1A476"), CardNumber = "3256874596325874", ClientName = "Bruce Banner", Cvc = 846, IssueDate = new DateTime(2021, 01, 01), ExpirationDate = new DateTime(2024, 01, 01), BankAccountId = Guid.Parse("56617F02-32FD-4C1A-83CE-341E7AF16A25") },
                new Card { Id = Guid.Parse("80B10D23-B9D4-415B-B247-2290C6752B93"), CardNumber = "8745102356985478", ClientName = "Bruce Banner", Cvc = 137, IssueDate = new DateTime(2021, 01, 01), ExpirationDate = new DateTime(2024, 01, 01), BankAccountId = Guid.Parse("56617F02-32FD-4C1A-83CE-341E7AF16A25") },
                new Card { Id = Guid.Parse("B5FABE04-1620-4750-8601-DF9C0D7DD2E3"), CardNumber = "1023547895235687", ClientName = "Wanda Maximoff", Cvc = 128, IssueDate = new DateTime(2021, 01, 01), ExpirationDate = new DateTime(2024, 01, 01), BankAccountId = Guid.Parse("5B5385B9-5157-4D4C-A883-1EA0C2BFF1ED") },
                new Card { Id = Guid.Parse("42BD14DA-8EBB-4344-9F07-8CD6BDB63675"), CardNumber = "2014258785693258", ClientName = "Victor Shade", Cvc = 129, IssueDate = new DateTime(2021, 01, 01), ExpirationDate = new DateTime(2024, 01, 01), BankAccountId = Guid.Parse("54BF5559-3DED-4338-98F5-02D18509E7FD") },
                new Card { Id = Guid.Parse("EDDB3EA9-6306-4225-9F9A-520028104D71"), CardNumber = "5024785695874253", ClientName = "Victor Shade", Cvc = 120, IssueDate = new DateTime(2021, 01, 01), ExpirationDate = new DateTime(2024, 01, 01), BankAccountId = Guid.Parse("52EF23AA-621F-4184-B88B-263F5F2E4B0F") },
                new Card { Id = Guid.Parse("8A486232-F9C5-4805-9858-862E4956F0D9"), CardNumber = "3256985620147452", ClientName = "Dane Whitman", Cvc = 112, IssueDate = new DateTime(2021, 01, 01), ExpirationDate = new DateTime(2024, 01, 01), BankAccountId = Guid.Parse("2F524819-7B82-404F-B55B-AF16D5FCF98E") },
                new Card { Id = Guid.Parse("DD7F6807-04DE-4190-81B4-914331A22CEF"), CardNumber = "3025485695874123", ClientName = "Dane Whitman", Cvc = 132, IssueDate = new DateTime(2021, 01, 01), ExpirationDate = new DateTime(2024, 01, 01), BankAccountId = Guid.Parse("2F524819-7B82-404F-B55B-AF16D5FCF98E") }
            );
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentSystem.SqlRepository.Models;
using System;

namespace PaymentSystem.SqlRepository.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasData
            (
                new Client { Id = Guid.Parse("EF74F0F4-FCCA-4751-A39E-4FAAE75F9123"), FirstName = "Thor", LastName = "Odinson", Address = "New York, Green Streen 13", DateCreated = new DateTime(2021, 01, 01), DateOfBirth = new DateTime(1973, 01, 11), PhoneNumber = "32568978568" },
                new Client { Id = Guid.Parse("16DB1414-387C-40D1-89E3-05945C4661A1"), FirstName = "Tony", LastName = "Stark", Address = "New York, Yellow Streen 11", DateCreated = new DateTime(2021, 02, 02), DateOfBirth = new DateTime(1985, 02, 12), PhoneNumber = "36589875659" },
                new Client { Id = Guid.Parse("C5A3B5DC-CAA1-4B00-987B-B3ACF0527397"), FirstName = "Bruce", LastName = "Banner", Address = "New York, Brown Streen 10", DateCreated = new DateTime(2021, 03, 03), DateOfBirth = new DateTime(1974, 03, 13), PhoneNumber = "34587965865" },
                new Client { Id = Guid.Parse("28E1DE8A-715A-4D50-8A08-2D86CACA0BB4"), FirstName = "Wanda", LastName = "Maximoff", Address = "New York, Red Streen 15", DateCreated = new DateTime(2021, 04, 04), DateOfBirth = new DateTime(1980, 04, 14), PhoneNumber = "32532547896" },
                new Client { Id = Guid.Parse("D7FAFCDD-FAF2-472D-9D52-4C9256C77149"), FirstName = "Victor", LastName = "Shade", Address = "New York, Black Streen 14", DateCreated = new DateTime(2021, 05, 05), DateOfBirth = new DateTime(1977, 05, 15), PhoneNumber = "32987563545" },
                new Client { Id = Guid.Parse("1D8F8003-FD0E-42B5-9F7E-05B766DE6340"), FirstName = "Dane", LastName = "Whitman", Address = "New York, White Streen 12", DateCreated = new DateTime(2021, 06, 06), DateOfBirth = new DateTime(1976, 06, 16), PhoneNumber = "36548998566" }
            );
        }
    }
}
using System;
using System.Collections.Generic;

namespace PaymentSystem.Tests
{
    public static class DataProvider
    {
        public static List<Domain.Client> GetClients()
        {
            return new List<Domain.Client>
            {
                new Domain.Client
                {
                    Id = Guid.Parse("A6CC42B2-B5B2-45CB-8E43-AF5C6E839A0E"),
                    Address = "Test address",
                    FirstName = "First",
                    LastName = "Last",
                    DateOfBirth = new DateTime(2000, 1, 1),
                    DateCreated = DateTime.Now,
                    PhoneNumber = "7895647998",
                    BankAccounts = new List<Domain.BankAccount>
                    {
                        new Domain.BankAccount
                        {
                            Id = Guid.Parse("F457C6AA-9F0F-47CE-98A5-75F4E82F3433"),
                            AmountOfMoney = 10000,
                            ClientId = Guid.Parse("A6CC42B2-B5B2-45CB-8E43-AF5C6E839A0E"),
                            DateCreated = DateTime.Now,
                            PaymentCards = new List<Domain.Card>
                            {
                                new Domain.Card
                                {
                                    Id = Guid.Parse("9BB18F1B-5578-4AE7-B450-7B1C5276CEB5"),
                                    BankAccountId = Guid.Parse("F457C6AA-9F0F-47CE-98A5-75F4E82F3433"),
                                    CardNumber = "1235425698567458",
                                    ClientName = "First Last",
                                    Cvc = 123,
                                    IssueDate = DateTime.Now,
                                    ExpirationDate = new DateTime(2025, 1, 1),
                                }
                            }
                        }
                    }
                },

                new Domain.Client
                {
                    Id = Guid.Parse("760614AF-B649-4404-B475-906BF860C21F"),
                    Address = "Test address",
                    FirstName = "Qwerty",
                    LastName = "Test",
                    DateOfBirth = new DateTime(2000, 1, 1),
                    DateCreated = DateTime.Now,
                    PhoneNumber = "7895647998",
                    BankAccounts = new List<Domain.BankAccount>
                    {
                        new Domain.BankAccount
                        {
                            Id = Guid.Parse("6BA4BA0D-C0CC-48B4-8D42-B95A08A69C15"),
                            AmountOfMoney = 10000,
                            ClientId = Guid.Parse("760614AF-B649-4404-B475-906BF860C21F"),
                            DateCreated = DateTime.Now,
                            PaymentCards = new List<Domain.Card>
                            {
                                new Domain.Card
                                {
                                    Id = Guid.Parse("DEB0B7AF-D483-4228-A39B-0B43D8E48A5F"),
                                    BankAccountId = Guid.Parse("6BA4BA0D-C0CC-48B4-8D42-B95A08A69C15"),
                                    CardNumber = "9658745863256985",
                                    ClientName = "Qwerty Test",
                                    Cvc = 123,
                                    IssueDate = DateTime.Now,
                                    ExpirationDate = new DateTime(2025, 1, 1),
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}

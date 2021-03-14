using System;

namespace PaymentSystem.Contract.Models
{
    public class Card
    {
        public string ClientName { get; set; }

        public Guid BankAccountId { get; set; }

        public string CardNumber { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public ushort Cvc { get; set; }

        public BankAccount BankAcount { get; set; }
    }
}

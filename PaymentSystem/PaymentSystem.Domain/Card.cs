using System;

namespace PaymentSystem.Domain
{
    public class Card
    {
        public Guid Id { get; set; }

        public Guid BankAccountId { get; set; }

        public string ClientName { get; set; }

        public string CardNumber { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public ushort Cvc { get; set; }       
    }
}

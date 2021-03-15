using System;

namespace PaymentSystem.Domain
{
    public class Transaction
    {
        public Guid Id { get; set; }

        public Guid SenderCardId { get; set; }

        public Guid RecipientCardId { get; set; }

        public double AmountOfMoney { get; set; }

        public DateTime DateCreated { get; set; }
    }
}

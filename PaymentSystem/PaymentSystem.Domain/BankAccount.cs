using System;
using System.Collections.Generic;

namespace PaymentSystem.Domain
{
    public class BankAccount
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public DateTime DateCreated { get; set; }

        public double AmountOfMoney { get; set; }

        public IEnumerable<Card> PaymentCards { get; set; }
    }
}

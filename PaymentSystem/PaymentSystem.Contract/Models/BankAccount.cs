using System;
using System.Collections.Generic;

namespace PaymentSystem.Contract.Models
{
    public class BankAccount
    {
        public Guid ClientId { get; set; }

        public DateTime DateCreated { get; set; }

        public double AmountOfMoney { get; set; }

        public IEnumerable<Card> PaymentCards { get; set; }
    }
}

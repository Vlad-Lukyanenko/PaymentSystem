using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentSystem.SqlRepository.Models
{
    public class BankAccount
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(Client))]
        public Guid ClientId { get; set; }

        public DateTime DateCreated { get; set; }

        public double AmountOfMoney { get; set; }

        public IEnumerable<Card> PaymentCards { get; set; }
    }
}

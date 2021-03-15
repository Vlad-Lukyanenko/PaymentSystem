using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentSystem.SqlRepository.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(Card))]
        public Guid SenderCardId { get; set; }

        [ForeignKey(nameof(Card))]
        public Guid RecipientCardId { get; set; }

        public double AmountOfMoney { get; set; }

        public DateTime DateCreated { get; set; }
    }
}

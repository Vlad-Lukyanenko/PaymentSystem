using System;
using System.Collections.Generic;

namespace PaymentSystem.Contract.Models
{
    public class Client
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<BankAccount> BankAccounts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.SqlRepository.Models
{
    public class Client
    {
        public Guid Id { get; set; }

        [MaxLength(25, ErrorMessage = "Maximum length for the First Name is 25 characters.")]
        public string FirstName { get; set; }

        [MaxLength(25, ErrorMessage = "Maximum length for the Second Name is 25 characters.")]
        public string LastName { get; set; }

        [MaxLength(250, ErrorMessage = "Maximum length for the Address is 250 characters.")]
        public string Address { get; set; }

        [MaxLength(15, ErrorMessage = "Maximum length for the Phone Number is 15 characters.")]
        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<BankAccount> BankAccounts { get; set; }
    }
}

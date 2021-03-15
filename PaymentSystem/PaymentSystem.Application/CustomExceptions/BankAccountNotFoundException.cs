using System;

namespace PaymentSystem.Application.CustomExceptions
{
    public class BankAccountNotFoundException : Exception
    {
        public BankAccountNotFoundException()
        {
        }

        public BankAccountNotFoundException(string message)
            : base(message)
        {
        }
    }
}

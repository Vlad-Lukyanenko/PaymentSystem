using System;

namespace PaymentSystem.Application.CustomExceptions
{
    public class DuplicateAccountException : Exception
    {
        public DuplicateAccountException()
        {
        }

        public DuplicateAccountException(string message)
            : base(message)
        {
        }
    }
}

using System;

namespace PaymentSystem.Application.CustomExceptions
{
    public class InvalidCardNumberException : Exception
    {
        public InvalidCardNumberException()
        {
        }

        public InvalidCardNumberException(string message)
            : base(message)
        {
        }
    }
}

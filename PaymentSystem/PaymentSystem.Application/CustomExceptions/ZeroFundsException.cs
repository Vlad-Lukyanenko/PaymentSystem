using System;

namespace PaymentSystem.Application.CustomExceptions
{
    public class ZeroFundsException : Exception
    {
        public ZeroFundsException()
        {
        }

        public ZeroFundsException(string message)
            : base(message)
        {
        }
    }
}

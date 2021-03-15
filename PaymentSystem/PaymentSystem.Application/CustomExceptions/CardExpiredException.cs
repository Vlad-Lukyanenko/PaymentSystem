using System;

namespace PaymentSystem.Application.CustomExceptions
{
    public class CardExpiredException : Exception
    {
        public CardExpiredException()
        {
        }

        public CardExpiredException(string message)
            : base(message)
        {
        }
    }
}

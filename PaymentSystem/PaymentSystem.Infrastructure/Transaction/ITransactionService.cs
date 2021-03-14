﻿using System.Threading.Tasks;

namespace PaymentSystem.Infrastructure.Transaction
{
    public interface ITransactionService
    {
        Task TransferMoneyAsync(string senderCardNumber, string RecipientCardId, decimal amountOfMoney);
    }
}
using Microsoft.Extensions.Options;
using PaymentSystem.Application.CustomExceptions;
using PaymentSystem.Domain;
using PaymentSystem.Infrastructure;
using PaymentSystem.Infrastructure.ConfigSettings;
using PaymentSystem.Infrastructure.Transaction;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PaymentSystem.Application
{
    public class TransactionService : ITransactionService
    {
        private const ushort LowerAccountLimit = 0;
        private readonly IRepositoryManager _repositoryManager;
        private readonly PaymentCardSettings _paymentCardSettings;

        public TransactionService(
            IRepositoryManager repositoryManager,
            IOptions<PaymentCardSettings> paymentCardSettings)
        {
            _repositoryManager = repositoryManager;
            _paymentCardSettings = paymentCardSettings.Value;
        }

        public async Task TransferMoneyAsync(string senderCardNumber, string recipientCardId, decimal amountOfMoney)
        {
            senderCardNumber = CreditCardValidator(senderCardNumber);
            recipientCardId = CreditCardValidator(recipientCardId);

            var sender = await _repositoryManager.BankAccount.GetMoneyFromAccountAsync(senderCardNumber, amountOfMoney);

            IfAccountExists(sender, senderCardNumber);
            IsEnoughCash(sender);

            var recipient = await _repositoryManager.BankAccount.PutMoneyIntoAccountAsync(recipientCardId, amountOfMoney);

            IfAccountExists(recipient, recipientCardId);
            IsDuplicateAccount(sender.Id, recipient.Id);

            var senderCardId = sender.PaymentCards.SingleOrDefault(c => c.CardNumber.Equals(senderCardNumber));
            var recepientCardId = recipient.PaymentCards.SingleOrDefault(c => c.CardNumber.Equals(recipientCardId));

            await LogTransactionAsync(senderCardId.Id, recepientCardId.Id, amountOfMoney);

            await _repositoryManager.SaveChangesAsync();
        }

        private async Task LogTransactionAsync(Guid senderCardId, Guid recipientCardId, decimal amountOfMoney)
        {
            var transaction = new Transaction
            {
                SenderCardId = senderCardId,
                RecipientCardId = recipientCardId,
                AmountOfMoney = amountOfMoney,
                DateCreated = DateTime.Now
            };

            await _repositoryManager.Transaction.CreateAsync(transaction);
        }

        private void IsDuplicateAccount(Guid senderId, Guid recipientId)
        {
            if (senderId == recipientId)
            {
                throw new DuplicateAccountException("You can transfer money between different account only");
            }
        }

        private void IfAccountExists(BankAccount account, string senderCardNumber)
        {
            if (account == null)
            {
                throw new BankAccountNotFoundException(BankAccountNotFoundMessage(senderCardNumber));
            }
        }

        private void IsEnoughCash(BankAccount account)
        {
            if (account.AmountOfMoney < LowerAccountLimit)
            {
                throw new InsufficientFundsException("Insufficient funds to complete the transaction");
            }
        }

        private string CreditCardValidator(string cardNumber)
        {
            cardNumber = cardNumber.Replace(" ", "");

            var cardCheck = new Regex(_paymentCardSettings.CardNumberFilter);

            if (!cardCheck.IsMatch(cardNumber))
            {
                throw new InvalidCardNumberException("Card number is not valid");
            }

            return cardNumber;
        }

        private string BankAccountNotFoundMessage(string cardNumber)
        {
            return $"Bank account was not found for the following card number = {cardNumber}";
        }
    }
}

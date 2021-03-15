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

        public async Task TransferMoneyAsync(string senderCardNumber, string recipientCardNumber, double amountOfMoney)
        {
            senderCardNumber = CreditCardValidator(senderCardNumber);
            recipientCardNumber = CreditCardValidator(recipientCardNumber);

            IsAmountOfMoneyMoreThenZero(amountOfMoney);

            var sender = await _repositoryManager.BankAccount.GetMoneyFromAccountAsync(senderCardNumber, amountOfMoney);

            IfAccountExists(sender, senderCardNumber);
            IsEnoughCash(sender);

            var recipient = await _repositoryManager.BankAccount.PutMoneyIntoAccountAsync(recipientCardNumber, amountOfMoney);

            IfAccountExists(recipient, recipientCardNumber);
            IsDuplicateAccount(sender.Id, recipient.Id);

            var senderCardId = sender.PaymentCards.SingleOrDefault(c => c.CardNumber.Equals(senderCardNumber));
            var recipientCardId = recipient.PaymentCards.SingleOrDefault(c => c.CardNumber.Equals(recipientCardNumber));

            await LogTransactionAsync(senderCardId.Id, recipientCardId.Id, amountOfMoney);

            await _repositoryManager.SaveChangesAsync();
        }

        private async Task LogTransactionAsync(Guid senderCardId, Guid recipientCardId, double amountOfMoney)
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

        private static void IsAmountOfMoneyMoreThenZero(double amountOfMoney)
        {
            if (amountOfMoney <= 0)
            {
                throw new ZeroFundsException("Amount of money to transfer should be greater than 0");
            }
        }

        private static void IsDuplicateAccount(Guid senderId, Guid recipientId)
        {
            if (senderId == recipientId)
            {
                throw new DuplicateAccountException("You can transfer money between different account only");
            }
        }

        private static void IfAccountExists(BankAccount account, string senderCardNumber)
        {
            if (account == null)
            {
                throw new BankAccountNotFoundException(BankAccountNotFoundMessage(senderCardNumber));
            }
        }

        private static void IsEnoughCash(BankAccount account)
        {
            if (account.AmountOfMoney < LowerAccountLimit)
            {
                throw new InsufficientFundsException("Insufficient funds to complete the transaction");
            }
        }

        private static string BankAccountNotFoundMessage(string cardNumber)
        {
            return $"Bank account was not found for the following card number = {cardNumber}";
        }

        private string CreditCardValidator(string cardNumber)
        {
            cardNumber = cardNumber.Replace(" ", string.Empty);

            var cardCheck = new Regex(_paymentCardSettings.CardNumberFilter);

            if (!cardCheck.IsMatch(cardNumber))
            {
                throw new InvalidCardNumberException("Card number is not valid");
            }

            return cardNumber;
        }
    }
}

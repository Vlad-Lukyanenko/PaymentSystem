using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaymentSystem.Application.CustomExceptions;
using PaymentSystem.Contract.Transport;
using PaymentSystem.Infrastructure.Transaction;
using System;
using System.Threading.Tasks;

namespace PaymentSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService, ILogger<TransactionController> logger)
        {
            _transactionService = transactionService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> CreateTransaction([FromBody] CreateTransactionRequest request)
        {
            try
            {
                await _transactionService.TransferMoneyAsync(request.SenderCardNumber, request.RecipientCardId, request.AmountOfMoney);
            }
            catch (BankAccountNotFoundException ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex) when (
                ex is CardExpiredException ||
                ex is InvalidCardNumberException ||
                ex is InsufficientFundsException ||
                ex is DuplicateAccountException ||
                ex is ZeroFundsException)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}

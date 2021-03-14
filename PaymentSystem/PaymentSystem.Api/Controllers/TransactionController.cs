using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Application.CustomExceptions;
using PaymentSystem.Contract.Transport;
using PaymentSystem.Infrastructure.Transaction;
using System.Threading.Tasks;

namespace PaymentSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
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
                return NotFound(ex.Message);
            }
            catch (CardExpiredException ex)
            { 
                return BadRequest(ex.Message);
            }
            catch (InvalidCardNumberException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InsufficientFundsException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DuplicateAccountException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}

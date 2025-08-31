using Atm.Application.Dtos;
using Atm.Application.Services;
using Atm.Domain.Exceptions;
using Atm.Infrastructure.Exceptions;
using Azure;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Atm.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    public class TransactionsController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;
        private readonly ITransactionService _transactionService;

        public TransactionsController(ILogger<TransactionsController> logger, ITransactionService  transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositDto depositDto)
        {
            try
            {
                int transactionId = await _transactionService.Deposit(depositDto);
                return Ok(transactionId);
            }
            catch (InvalidTransactionAmountException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (UniqueConstraintException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
            catch (InfrastructureException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("Withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawDto withdrawDto)
        {
            try
            {
                int transactionId = await _transactionService.Withdraw(withdrawDto);
                return Ok(transactionId);
            }
            catch (InvalidAccountBalanceException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (InvalidTransactionAmountException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (UniqueConstraintException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
            catch (InfrastructureException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("Transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransferDto transferDto)
        {
            try
            {
                int transferId = await _transactionService.Transfer(transferDto);
                return Ok(transferId);
            }
            catch (InvalidAccountBalanceException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (InvalidTransactionAmountException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (UniqueConstraintException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
            catch (InfrastructureException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Transaction()
        {
            //Records every financial movement as a double-entry transaction (debits and credits)
            //It provides an unchangeable, auditable history. All other services can rebuild their state from the ledger's data if needed.
            await Task.Delay(1000);
            await Task.CompletedTask;
            return Ok();
        }        
    }
}

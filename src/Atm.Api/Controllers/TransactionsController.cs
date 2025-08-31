using Atm.Application.Dtos;
using Atm.Application.Services;
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
            int transactionId = await _transactionService.Deposit(depositDto);
            return Ok(transactionId);
        }

        [HttpPost("Withdraw")]
        public async Task<IActionResult> Withdraw()
        {
            await Task.Delay(1000);
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPost("Transfer")]
        public async Task<IActionResult> Transfer()
        {
            await Task.Delay(1000);
            await Task.CompletedTask;
            return Ok();
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

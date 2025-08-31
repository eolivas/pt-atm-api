using Atm.Application.Services;
using Atm.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atm.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransactionsHistoryController : ControllerBase
    {
        private readonly ILogger<TransactionsHistoryController> _logger;
        private readonly ITransactionService _transactionService;

        public TransactionsHistoryController(ILogger<TransactionsHistoryController> logger, ITransactionService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> TransactionsHistoryByAccountId([FromRoute] int accountId)
        {
            IEnumerable<Transaction> transactions = await _transactionService.GetTransactionsByAccountId(accountId);
            return Ok(transactions);
        }

        [HttpGet("DateRange/{accountId}")]
        public async Task<IActionResult> TransactionsHistoryByAccountIdAndDateRange([FromRoute] int accountId, [FromQuery] DateTime startDate, DateTime endDate)
        {
            IEnumerable<Transaction> transactions = await _transactionService.GetByAccountIdAndDateRange(accountId, startDate, endDate);
            return Ok(transactions);
        }
    }
}

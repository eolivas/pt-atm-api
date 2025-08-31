using Microsoft.AspNetCore.Mvc;

namespace Atm.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransactionsHistoryController : ControllerBase
    {
        private readonly ILogger<TransactionsHistoryController> _logger;

        public TransactionsHistoryController(ILogger<TransactionsHistoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> TransactionsHistory()
        {
            await Task.Delay(1000);
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet("Balance/{Id}")]
        public async Task<IActionResult> TransactionsBalance()
        {
            await Task.Delay(1000);
            await Task.CompletedTask;
            return Ok();
        }
    }
}

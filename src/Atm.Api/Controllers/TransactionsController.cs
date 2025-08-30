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

        public TransactionsController(ILogger<TransactionsController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit()
        {
            await Task.Delay(1000);
            await Task.CompletedTask;
            return Ok();
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
    }
}

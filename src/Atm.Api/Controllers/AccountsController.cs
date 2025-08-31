using Microsoft.AspNetCore.Mvc;

namespace Atm.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(ILogger<AccountsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Balance")]
        public async Task<IActionResult> Balance()
        {
            await Task.Delay(1000);
            await Task.CompletedTask;
            return Ok(7589.59);
        }
    }
}

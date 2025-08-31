using Atm.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Atm.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IAccountService _accountService;

        public AccountsController(ILogger<AccountsController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpGet("Balance/{id}")]
        public async Task<IActionResult> Balance([FromRoute] int id)
        {
            try
            {
                decimal balance = await _accountService.GetAccountBalance(id);
                return Ok(balance);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Wallet.Api.Controllers;

[ApiController]
[Route("api/currencies")]
[Produces("application/json")]
[Consumes("application/json")]
public class CurrenciesController: ControllerBase
{
    public async Task<IActionResult> Get()
    {
        return Ok();
    }
}
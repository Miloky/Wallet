using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wallet.Api.Domain;
using Wallet.Api.Models;

namespace Wallet.Api.Controllers;

[ApiController]
[Route("api/accounts")]
[Produces("application/json")]
[Consumes("application/json")]
public class AccountsController:ControllerBase
{
    private readonly WalletDbContext _context;

    public AccountsController(WalletDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        var account = await _context.Accounts.FirstOrDefaultAsync(acc => acc.Id == id);
        if (account == null)
        {
            return NotFound();
        }

        // TODO: Dto
        return Ok(account);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAccountRequest request)
    {
        var currency = await 
            _context.Currencies.FirstOrDefaultAsync(curr => curr.AlphabeticCode == request.CurrencyAlphabeticCode);

        if (currency == null)
        {
            // TODO: Provide bad request message
            // TODO: Add translations for bad request messages 
            return BadRequest();
        }
        
        // TODO: Automapper 
        var account = new Account
        {
            Name = request.Name,
            Currency = currency
        };

        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();

        return Ok(new IdResponse<int>(account.Id));
    }
}
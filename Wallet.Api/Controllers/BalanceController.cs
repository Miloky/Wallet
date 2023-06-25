using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wallet.Api.Domain;

namespace Wallet.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
[Route("api/balance")]
public class BalanceController:ControllerBase
{
    private readonly WalletDbContext _context;

    public BalanceController(WalletDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Get()
    {
       var sum = await _context.Transactions.SumAsync(t => t.Amount * GetSign(t.Type));
       return Ok(new { Amount = sum });
    }

    private decimal GetSign(TransactionType type)
    {
        const decimal positive = 1;
        const decimal negative = -1;
        switch (type)
        {
            case TransactionType.Expense: return negative;
            case TransactionType.Income: return positive;
            case TransactionType.Transfer: return negative;
            default: return positive;
        }
    }
}
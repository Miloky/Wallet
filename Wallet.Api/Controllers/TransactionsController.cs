using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wallet.Api.Domain;
using Wallet.Api.Models;

namespace Wallet.Api.Controllers;

[ApiController]
[Route("api/transactions")]
[Produces("application/json")]
[Consumes("application/json")]
public class TransactionsController: ControllerBase
{
    private readonly WalletDbContext _context;

    public TransactionsController(WalletDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
       var transaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == id);
       if (transaction == null)
       {
           return NotFound();
       }
       
       // TODO: Map to dto
       return Ok(transaction);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTransactionRequest request)
    {
        // TODO: Add automapper
        var transaction = new Transaction
        {
            Name = request.Name,
            Description = request.Description,
            Amount = request.Amount
        };
        await _context.Transactions.AddAsync(transaction);

        await _context.SaveChangesAsync();

        return Ok(new { transaction.Id });
    }
}
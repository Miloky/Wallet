using AutoMapper;
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
    private readonly IMapper _mapper;

    public AccountsController(WalletDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var accounts = await _context.Accounts.ToListAsync();
        return Ok(accounts);
    }

    [HttpGet("{id}")]
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
        var account = _mapper.Map<Account>(request);
        
        
        // TODO: Validation
        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();

        return Ok(new IdResponse<int>(account.Id));
    }
}
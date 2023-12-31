using AutoMapper;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wallet.Api.Domain;
using Wallet.Api.Models;

namespace Wallet.Api.Controllers;

[ApiController]
[Route("api/transactions")]
[Produces("application/json")]
[Consumes("application/json")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class TransactionsController : ControllerBase
{
	private readonly WalletDbContext _context;
	private readonly IMapper _mapper;

	public TransactionsController(WalletDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> Get(int id)
	{
		var transaction = await _context.Transactions.Include(x => x.Account).FirstOrDefaultAsync(t => t.Id == id);
		if (transaction == null)
		{
			return NotFound();
		}

		// TODO: Map to dto
		return Ok(transaction);
	}

	[HttpPost("{id}/attachments")]
	public async Task<IActionResult> UploadAttachments([FromRoute] int id, [FromHeader] int userId)
	{
		var files = Request.Form.Files;
		if (files?.Any() != true)
		{
			return BadRequest("Please provide files.");
		}

		BlobContainerClient blobContainerClient = new BlobContainerClient(
			"AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;", id.ToString());

		await blobContainerClient.CreateIfNotExistsAsync();



		foreach (var file in files)
		{
			await blobContainerClient.UploadBlobAsync(file.FileName, file.OpenReadStream());
		}


		return Ok();
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateTransactionRequest request)
	{
		var account = await _context.Accounts.FirstOrDefaultAsync(acc => acc.Id == request.AccountId);
		if (account == null)
		{
			return BadRequest(new { message = "Account not found!" });
		}

		var transaction = _mapper.Map<Transaction>(request);


		await using (var dbContextTransaction = await _context.Database.BeginTransactionAsync())
		{

			await _context.Transactions.AddAsync(transaction);

			account.Balance += GetAmountWithSign(transaction.Type, transaction.Amount);
			_context.Accounts.Update(account);

			await _context.SaveChangesAsync();
			await dbContextTransaction.CommitAsync();
		}

		return Ok(new IdResponse<int>(transaction.Id));
	}

	// TODO Add validation for id
	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		var transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);

		if (transaction == null)
		{
			return NotFound($"Transaction with id={id} was not found!");
		}


		await using (var dbContextTransaction = await _context.Database.BeginTransactionAsync())
		{
			try
			{
				var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == transaction.AccountId)!;
				_context.Transactions.Remove(transaction);
				account.Balance -= GetAmountWithSign(transaction.Type, transaction.Amount);
				await _context.SaveChangesAsync();
				await dbContextTransaction.CommitAsync();

			}
			catch
			{
				await dbContextTransaction.RollbackAsync();
			}
		}

		return Ok();
	}

	private decimal GetAmountWithSign(TransactionType type, decimal amount)
	{
		return type switch
		{
			TransactionType.Expense => -amount,
			TransactionType.Transfer => -amount,
			TransactionType.Income => amount,
			_ => amount
		};
	}
}
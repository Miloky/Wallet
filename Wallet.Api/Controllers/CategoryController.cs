using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wallet.Api.Domain;

[ApiController]
[Route("api/categories")]
[Produces("application/json")]
[Consumes("application/json")]
public class CategoryController : ControllerBase
{
	private readonly WalletDbContext _context;

	public CategoryController(WalletDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		var categories = await _context.Categories.Include(x => x.SubCategories).ToArrayAsync();
		var json = JsonSerializer.Serialize(categories, new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			ReferenceHandler = ReferenceHandler.IgnoreCycles
		});

		return new JsonResult(categories, new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			ReferenceHandler = ReferenceHandler.IgnoreCycles
		});
	}
}
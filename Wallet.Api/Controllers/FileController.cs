using Microsoft.AspNetCore.Mvc;

namespace Wallet.Api.Controllers;

[ApiController]
[Route("api/files")]
public class FileController : ControllerBase
{
    private readonly string _uploadFolder;
    public FileController(IWebHostEnvironment environment)
    {
	    _uploadFolder = Path.Combine(environment.WebRootPath, "uploads");
    }

    [HttpPost("transaction/{transactionId:int}/upload")]
    public async Task<IActionResult> Upload([FromRoute] int transactionId)
    {
        // TODO: File metadata should be stored in database
        // Such information should contain
        // 1. File size
        // 2. Upload data
        // 3. File name
        // 4. Uploaded by
        // 5. Related transaction



        var file = HttpContext.Request.Form.Files.FirstOrDefault();
        file.
        if (file == null)
        {
            return BadRequest("File is null");
        }

        var path = GetUploadPath(transactionId);

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        await using var stream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create);
        await using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        var fileBytes = memoryStream.ToArray();
        await stream.WriteAsync(fileBytes);

        return Ok();
    }

    [HttpGet("transaction/{transactionId:int}")]
    public async Task<IActionResult> GetFiles(int transactionId)
    {
	    var path = GetUploadPath(transactionId);

	    if (!Directory.Exists(path))
	    {
		    return NotFound("There is no files for this transaction");
	    }

	    var files =   Directory.EnumerateFiles(path);

        // TODO: Create model for response, should contain metadata for file 
	    return Ok(new
	    {
            TransactionId = transactionId,
            Files = files
	    });
    }

    private string GetUploadPath(int transactionId) => Path.Combine(_uploadFolder, transactionId.ToString());
}
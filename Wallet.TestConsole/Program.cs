using Azure.Storage.Blobs;

internal static class Program
{
	private static async Task Main(string[] args)
	{
		Console.WriteLine("Hello, World!");

		BlobContainerClient blobContainerClient = new BlobContainerClient(
			"AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;", "test2");
		await blobContainerClient.CreateIfNotExistsAsync();

		var stream = File.OpenRead("C:/Users/vlshe/Documents/code/Wallet/Wallet.Api/wwwroot/uploads/2/a.pdf");

		//var a =await blobContainerClient.UploadBlobAsync("tttttt888/file.pdf", stream);

		var blobClient = blobContainerClient.GetBlobClient("tttttt888/file.pdf");
		var file = await blobClient.DownloadContentAsync();

		//blobContainerClient.UploadBlobAsync();
	}

	public interface IBlobService
	{

	};

	public class User
	{
		public int Id { get; set; }
	}

	//public class FileTransactionMapping
	//{
	//	public 
	//}

	public class FileMetadata
	{
		/// <summary>
		/// Id of file metadata.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// File name.
		/// </summary>
		public string Name { get; set; }
		
		/// <summary>
		/// File description.
		/// </summary>
		public string? Description { get; set; }
		
		/// <summary>
		/// Size in bytes.
		/// </summary>
		public long Size { get; set; }
	}

	public class BlobService
	{
		private readonly BlobContainerClient _blobContainerClient = new(
			"AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;", "test2");

		//public static BlobService Create(string containerName)
		//{
		//    return new 
		//}

		public async Task UploadBlobAsync(string name, Stream stream)
		{
			var a = await _blobContainerClient.GetBlobClient("fdsfs").OpenReadAsync();
			//a.

			await _blobContainerClient.UploadBlobAsync(name, stream);
		}
	}
}
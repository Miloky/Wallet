namespace Wallet.Api.Domain;

public class FileMetadata
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public long Size { get; set; }
}
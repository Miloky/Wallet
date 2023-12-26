using Azure.Storage.Blobs;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");


        Uri accountUri = new Uri("https://MYSTORAGEACCOUNT.blob.core.windows.net/");
        BlobServiceClient client = new BlobServiceClient(accountUri, new DefaultAzureCredential());
    }
}
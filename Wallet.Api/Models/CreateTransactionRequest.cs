namespace Wallet.Api.Models;

public class CreateTransactionRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
}
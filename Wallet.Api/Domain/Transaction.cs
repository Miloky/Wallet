namespace Wallet.Api.Domain;

public class Transaction
{
    public int Id { get; set; }
    public string Name { get; set; }
    public TransactionType Type { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
}
namespace Wallet.Api.Domain;

public class Transaction: Entity
{
    public int Id { get; set; }
    public TransactionType Type { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; }
    public DateTime Date { get; set; }
    public string Payee { get; set; }
    public string Note { get; set; }
}
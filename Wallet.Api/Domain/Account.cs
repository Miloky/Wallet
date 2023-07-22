namespace Wallet.Api.Domain;

public class Account : Entity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
}
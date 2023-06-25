namespace Wallet.Api.Models;

public class CreateAccountRequest
{
    public string Name { get; set; }
    public string CurrencyAlphabeticCode { get; set; }
}
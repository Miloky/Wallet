using System.ComponentModel.DataAnnotations;

namespace Wallet.Api.Models;

public class CreateAccountRequest
{
    [Required]
    public string Name { get; set; }

    [Range(0, int.MaxValue)]
    public decimal InitialBalance { get; set; } = 0;
}
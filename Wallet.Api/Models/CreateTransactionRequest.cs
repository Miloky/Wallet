using System.ComponentModel.DataAnnotations;
using Wallet.Api.Domain;

namespace Wallet.Api.Models;

public class CreateTransactionRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    [Required]
    public int AccountId { get; set; }
    public TransactionType Type { get; set; }
}
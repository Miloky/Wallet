namespace Wallet.Api.Domain.Common;

public abstract class Entity
{
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int CreatedBy { get; set; }
    public int ModifiedBy { get; set; }
}
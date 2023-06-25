namespace Wallet.Api.Models;

public class IdResponse<T>
{
    public IdResponse(){}

    public IdResponse(T id)
    {
        Id = id;
    }
    
    public T Id { get; }
}
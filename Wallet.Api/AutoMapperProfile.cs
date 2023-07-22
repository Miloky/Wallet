using AutoMapper;
using Wallet.Api.Domain;
using Wallet.Api.Models;

namespace Wallet.Api;

public static class MappingExpressionExtensions
{
    public static IMappingExpression<TSource, TDest> IgnoreAllUnmapped<TSource, TDest>(
        this IMappingExpression<TSource, TDest> expression)
    {
        expression.ForAllMembers(opt => opt.Ignore());
        return expression;
    }
}



public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateAccountRequest, Account>()
            .ForMember(
                x => x.Balance, 
                opt => opt.MapFrom(x => x.InitialBalance)
                );
        CreateMap<CreateTransactionRequest, Transaction>();
    }
}
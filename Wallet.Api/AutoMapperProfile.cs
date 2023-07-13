using AutoMapper;
using Wallet.Api.Domain;
using Wallet.Api.Models;

namespace Wallet.Api;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateAccountRequest, Account>();
    }
}
using Auction.DTOs;
using Auction.Entities;
using AutoMapper;

namespace Auction.Mappers;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<User, UserRegisterDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserLoginDto>().ReverseMap();
        CreateMap<Wallet, WalletDto>().ReverseMap();
    }
}
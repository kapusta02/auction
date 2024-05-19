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
        CreateMap<Wallet, WalletCreateDto>().ReverseMap();
        CreateMap<Wallet, WalletUpdateDto>().ReverseMap();
        CreateMap<WalletCreateDto, WalletUpdateDto>().ReverseMap();

        CreateMap<Lot, LotDto>().ReverseMap();
        CreateMap<Lot, LotCreateDto>().ReverseMap();
        CreateMap<Lot, LotUpdateDto>().ReverseMap();

        CreateMap<Bid, BidDto>().ReverseMap();
        CreateMap<Bid, BidCreateDto>().ReverseMap();
    }
}
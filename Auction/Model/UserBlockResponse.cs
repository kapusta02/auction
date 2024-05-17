using Auction.DTOs;
using Auction.Enums;

namespace Auction.Model;

public class UserBlockResponse
{
    public UserBlockResult Result { get; set; }
    public UserDto? User { get; set; }
}
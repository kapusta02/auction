namespace Auction.DTOs;

public class UserBlockDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public bool IsBlocked { get; set; }
}
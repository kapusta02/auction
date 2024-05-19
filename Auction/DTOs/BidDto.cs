namespace Auction.DTOs;

public class BidDto
{
    public Guid Id { get; set; }
    public string UserId { get; set; } = "";
    public Guid LotId { get; set; }
    public decimal Sum { get; set; }
    public DateTime CreatedAt { get; set; }
}
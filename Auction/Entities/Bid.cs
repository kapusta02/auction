namespace Auction.Entities;

public class Bid
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public decimal Sum { get; set; }
    public Guid LotId { get; set; }
    public Lot Lot { get; set; } = null!;
    public string UserId { get; set; }
    public User User { get; set; } = null!;
}
namespace Auction.Entities;

public class Lot
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string UserId { get; set; } = "";
    public User User { get; set; } = null!;
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string ImageLink { get; set; } = "";
    public decimal StartPrice { get; set; }
    public string Tags { get; set; } = "";
    public DateTime TradingStart { get; set; }
    public int TradingDurationMinutes { get; set; }
    public Guid? CurrentLeadingBidId { get; set; }
    public bool IsBiddingStarted { get; set; }
    public bool IsArchived { get; set; }
}
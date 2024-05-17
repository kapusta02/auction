namespace Auction.Entities;

public class Lot
{
    public Guid Id { get; set; }
    public string UserId { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string Images { get; set; } = "";
    public decimal StartPrice { get; set; }
    public string Tags { get; set; } = "";
    public DateTime TradingStart { get; set; }
    public DateTime TradingDuration { get; set; }
    public Guid BiddingId { get; set; }
}
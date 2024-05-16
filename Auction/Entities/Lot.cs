namespace Auction.Entities;

public class Lot
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Images { get; set; }
    public double StartPrice { get; set; }
    public string Tags { get; set; }
    public DateTime TradingStart { get; set; }
    public string TradingDuration { get; set; }
}
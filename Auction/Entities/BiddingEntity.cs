namespace Auction.Entities;

public class BiddingEntity
{
    public Guid Id { get; set; }
    public Guid LotId { get; set; }
    public Guid UserId { get; set; }
    public double Bid { get; set; }
    public double FinalPrice { get; set; }
}
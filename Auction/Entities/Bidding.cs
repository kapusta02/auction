namespace Auction.Entities;

public class Bidding
{
    public Guid Id { get; set; }
    public List<Lot> Lot { get; set; } = null!;
    public List<User> User { get; set; } = null!;
    
    public decimal Bid { get; set; }
    public decimal FinalPrice { get; set; }
}
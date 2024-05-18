namespace Auction.Entities;

public class Bidding
{
    public Guid Id { get; set; }
    public decimal Bids { get; set; }
    public decimal FinalPrice { get; set; }
    public bool IsBindingsStarted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<Lot> Lot { get; set; } = null!;
    public List<User> User { get; set; } = null!;
}
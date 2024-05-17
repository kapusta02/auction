namespace Auction.Entities;

public class Bidding
{
    public Guid Id { get; set; }
    public decimal Bid { get; set; }
    public decimal FinalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsArchived { get; set; }
    public List<Lot> Lot { get; set; } = null!;
    public List<User> User { get; set; } = null!;
}
namespace Auction.DTOs;

public class BiddingDto
{
    public decimal Bids { get; set; }
    public decimal FinalPrice { get; set; }
    public bool IsBindingsStarted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
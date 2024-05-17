namespace Auction.Entities;

public class Wallet
{
    public Guid Id { get; set; }
    public decimal Balance { get; set; }
    public string Currency = "Kaspi Coin";
    public string UserId { get; set; } = "";
    public User User { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
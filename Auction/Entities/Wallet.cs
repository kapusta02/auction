namespace Auction.Entities;

public class Wallet
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public decimal Sum { get; set; }
    public string Currency = "Kaspi Coin";
    public string UserId { get; set; }
    public User User { get; set; } = null!;
}
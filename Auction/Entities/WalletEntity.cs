namespace Auction.Entities;

public class WalletEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public double Balance { get; set; }
    public string Currency = "Kaspi Coin";
}
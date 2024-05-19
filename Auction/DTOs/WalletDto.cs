namespace Auction.DTOs;

public class WalletDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public decimal Sum { get; set; }
    public string Currency = "Kaspi Coin";
    public string UserId { get; set; } = "";
}
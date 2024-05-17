using System.ComponentModel.DataAnnotations;

namespace Auction.DTOs;

public class WalletUpdateBalance
{
    [Required(ErrorMessage = "Пожалуйста введите сумму")]
    [Range(0, 999999, ErrorMessage = "Максимум 6 символов")]
    [DataType(DataType.Currency)]
    public decimal Balance { get; set; }

    [Required(ErrorMessage = "Пожалуйста введите userId")]
    [StringLength(36, ErrorMessage = "Максимум 36 символов")]
    [DataType(DataType.Text)]
    public string UserId { get; set; } = "";
}
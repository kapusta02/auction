using System.ComponentModel.DataAnnotations;

namespace Auction.DTOs;

public class WalletUpdateDto
{
    [Required(ErrorMessage = "Пожалуйста введите walletId")]
    [DataType(DataType.Text)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Пожалуйста введите userId")]
    [StringLength(36, ErrorMessage = "Максимум 36 символов")]
    [DataType(DataType.Text)]
    public string UserId { get; set; } = "";

    [Required(ErrorMessage = "Пожалуйста введите сумму")]
    [Range(1, 999999, ErrorMessage = "Пожалуйста введите положительное число от 1 до 999999")]
    [DataType(DataType.Currency)]
    public decimal Sum { get; set; }
}
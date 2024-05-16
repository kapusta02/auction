using System.ComponentModel.DataAnnotations;

namespace Auction.DTOs;

public class WalletCreateDto
{
    [Required(ErrorMessage = "Пожалуйста введите сумму")]
    [Range(0, 999999, ErrorMessage = "Максимум 6 символов")]
    [DataType(DataType.Currency)]
    public decimal Balance { get; set; }
}
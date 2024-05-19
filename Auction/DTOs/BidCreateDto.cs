using System.ComponentModel.DataAnnotations;

namespace Auction.DTOs;

public class BidCreateDto
{
    [Required(ErrorMessage = "Пожалуйста введите userId")]
    [DataType(DataType.Text)]
    public string UserId { get; set; } = "";
    
    [Required(ErrorMessage = "Пожалуйста введите userId")]
    [DataType(DataType.Text)]
    public Guid LotId { get; set; }
    
    [Required(ErrorMessage = "Пожалуйста введите сумму")]
    [Range(0, 999999, ErrorMessage = "Максимум 6 символов")]
    [DataType(DataType.Currency)]
    public decimal Sum { get; set; }
}
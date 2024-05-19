using System.ComponentModel.DataAnnotations;

namespace Auction.DTOs;

public class LotCreateDto
{
    [Required(ErrorMessage = "Пожалуйста введите название лота")]
    [StringLength(256, ErrorMessage = "Максимум 256 символов")]
    [DataType(DataType.Text)]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Пожалуйста введите описание лота")]
    [StringLength(500, ErrorMessage = "Максимум 500 символов")]
    [DataType(DataType.Text)]
    public string Description { get; set; } = "";

    [Required(ErrorMessage = "Пожалуйста добавьте фотографию лота")]
    [StringLength(256, ErrorMessage = "Максимум 256 символов")]
    [DataType(DataType.Text)]
    public string ImageLink { get; set; } = "";

    [Required(ErrorMessage = "Пожалуйста введите начальную стоимость лота")]
    [Range(1, 9999, ErrorMessage = "Введите положительную сумму от 1 до 9999")]
    [DataType(DataType.Currency)]
    public decimal StartPrice { get; set; }

    [Required(ErrorMessage = "Пожалуйста добавьте теги к лоту")]
    [StringLength(15, ErrorMessage = "Максимум 15 символов")]
    [DataType(DataType.Text)]
    public string Tags { get; set; } = "";

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime TradingStart { get; set; }

    [Range(1, 9999, ErrorMessage = "Введите положительное число от 1 до 9999")]
    public int TradingDurationMinutes { get; set; }

    [Required(ErrorMessage = "Пожалуйста введите userId")]
    [StringLength(36, ErrorMessage = "Максимум 36 символов")]
    [DataType(DataType.Text)]
    public string UserId { get; set; } = "";
}
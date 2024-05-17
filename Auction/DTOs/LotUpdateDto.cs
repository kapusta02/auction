using System.ComponentModel.DataAnnotations;

namespace Auction.DTOs;

public class LotUpdateDto
{
    [Required(ErrorMessage = "Пожалуйста введите название лота")]
    [StringLength(20, ErrorMessage = "Максимум 20 символов")]
    [DataType(DataType.Text)]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Пожалуйста введите описание лота")]
    [StringLength(40, ErrorMessage = "Максимум 40 символов")]
    [DataType(DataType.Text)]
    public string Description { get; set; } = "";

    [Required(ErrorMessage = "Пожалуйста добавьте фотографию лота")]
    [StringLength(80, ErrorMessage = "Максимум 80 символов")]
    [DataType(DataType.Text)]
    public string Images { get; set; } = "";

    [Required(ErrorMessage = "Пожалуйста введите начальную стоимость лота")]
    [Range(0, 9999, ErrorMessage = "Максимум 4 символа")]
    [DataType(DataType.Currency)]
    public decimal StartPrice { get; set; }

    [Required(ErrorMessage = "Пожалуйста добавьте теги к лоту")]
    [StringLength(15, ErrorMessage = "Максимум 15 символов")]
    [DataType(DataType.Text)]
    public string Tags { get; set; } = "";

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime TradingStart { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime TradingDuration { get; set; }
    
    [Required(ErrorMessage = "Пожалуйста введите userId")]
    [StringLength(36, ErrorMessage = "Максимум 36 символов")]
    [DataType(DataType.Text)]
    public string UserId { get; set; }
}
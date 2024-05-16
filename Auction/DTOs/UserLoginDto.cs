using System.ComponentModel.DataAnnotations;

namespace Auction.DTOs;

public class UserLoginDto
{
    [Required(ErrorMessage = "Email не может быть пустым")]
    [StringLength(40, MinimumLength = 5, ErrorMessage = "Email не может быть короче 5 символов и длиннее 40")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(
        @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$",
        ErrorMessage = "Email не валиден")]
    public string Email { get; set; } = "";

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Необходимо ввести пароль")]
    public string Password { get; set; } = "";
}
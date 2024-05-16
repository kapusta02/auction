using System.ComponentModel.DataAnnotations;

namespace Auction.DTOs;

public class UserRegisterDto
{
    [Required(ErrorMessage = "Пожалуйста введите имя")]
    [StringLength(40, ErrorMessage = "Максимум 40 символов")]
    [DataType(DataType.Text)]
    public string FirstName { get; set; } = "";

    [Required(ErrorMessage = "Пожалуйста введите фамилию")]
    [StringLength(40, ErrorMessage = "Максимум 40 символов")]
    [DataType(DataType.Text)]
    public string LastName { get; set; } = "";

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
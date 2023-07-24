using System.ComponentModel.DataAnnotations;

namespace CleanMvc.API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Informe o Email")]
        [EmailAddress(ErrorMessage = "Informe o Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        [StringLength(20, ErrorMessage = "A senha tem que ter no máximo 20 caracteres", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CleanMvc.WebUI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o Email")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(20, ErrorMessage = "A senha tem que ter no máximo 20 caracteres", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public string ReturnUrl { get; set; }
    }
}

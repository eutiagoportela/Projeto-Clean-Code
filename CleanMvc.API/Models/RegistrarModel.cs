using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CleanMvc.API.Models
{
    public class RegistrarModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Senha", ErrorMessage = "As senhas não correspondem")]
        public string ConfirmPassword { get; set; }
    }
}

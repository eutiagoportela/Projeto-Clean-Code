

using System.ComponentModel.DataAnnotations;

namespace CleanMvc.Application.DTOs;

public class CategoriaDTO
{

    public int Id { get; set; }

    [Required(ErrorMessage ="Informe o Nome")]
    [MinLength(3)]
    [MaxLength(100)]
    public string Nome { get; set; }
}

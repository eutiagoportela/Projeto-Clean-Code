

using CleanMvc.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CleanMvc.Application.DTOs;

public class ProdutoDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o Nome")]
    [MinLength(3)]
    [MaxLength(100)]
    public string Nome { get;  set; }

    [Required(ErrorMessage = "Informe a Descrição")]
    [MinLength(5)]
    [MaxLength(200)]
    public string Descricao { get;  set; }

    [Required(ErrorMessage = "Informe o Preço")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString ="{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Price")]
    public decimal Preco { get;  set; }

    [Required(ErrorMessage = "Informe o Estoque")]
    [Range(1,9999)]
    [DisplayName("Estoque")]
    public int Estoque { get;  set; }

    [MaxLength(250)]
    [DisplayName("Imagem do Produto")]
    public string Imagem { get;  set; }

    [JsonIgnore]
    public Categoria? Categoria { get; set; }

    [DisplayName("Categoria")]
    public int CategoriaId { get; set; }
}

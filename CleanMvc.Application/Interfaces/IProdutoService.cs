

using CleanMvc.Application.DTOs;

namespace CleanMvc.Application.Interfaces;


public interface IProdutotService
{
    Task<IEnumerable<ProdutoDTO>> GetProdutos();
    Task<ProdutoDTO> GetById(int? id);

    Task<ProdutoDTO> GetProdutoCategoria(int? id);

    Task Add(ProdutoDTO productDto);
    Task Update(ProdutoDTO productDto);
    Task Remove(int? id);
}

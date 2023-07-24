

using CleanMvc.Domain.Entities;

namespace CleanMvc.Domain.Interfaces;

public interface IProdutoRepositorio
{
    Task<IEnumerable<Produto>> GetProdutosAsync();
    Task<Produto> GetById(int? id);

    Task<Produto> GetProdutoCategoriaAsync(int? id);

    Task<Produto> CriaraAsync(Produto produto);
    Task<Produto> AtualizarAsync(Produto produto);
    Task<Produto> RemoverAsync(Produto produto);
}

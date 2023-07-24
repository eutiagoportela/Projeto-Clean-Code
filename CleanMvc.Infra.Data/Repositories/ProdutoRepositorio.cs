
using CleanMvc.Domain.Entities;
using CleanMvc.Domain.Interfaces;
using CleanMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanMvc.Infra.Data.Repositories;

public class ProdutoRepositorio : IProdutoRepositorio
{
    ApplicationDbContext _produtoContext;

    public ProdutoRepositorio(ApplicationDbContext context)
    {
        _produtoContext = context;
    }

    public async Task<Produto> AtualizarAsync(Produto produto)
    {
        _produtoContext.Update(produto);
        await _produtoContext.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> CriaraAsync(Produto produto)
    {
        _produtoContext.Add(produto);
        await _produtoContext.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> GetById(int? id)
    {

        return await _produtoContext.Produtos.FindAsync(id);
    }

    public async Task<Produto> GetProdutoCategoriaAsync(int? id)
    {
        //eager loading
        return await _produtoContext.Produtos.Include(c => c.Categoria).SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Produto>> GetProdutosAsync()
    {
        return await _produtoContext.Produtos.ToListAsync();    
    }

    public async Task<Produto> RemoverAsync(Produto produto)
    {
        _produtoContext.Remove(produto);
        await _produtoContext.SaveChangesAsync();
        return produto;
    }
}

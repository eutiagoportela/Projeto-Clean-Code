
using CleanMvc.Domain.Entities;
using CleanMvc.Domain.Interfaces;
using CleanMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanMvc.Infra.Data.Repositories;

public class CategoriaRepositorio : ICategoriaRepositorio
{
    ApplicationDbContext _categoriaContext;

    public CategoriaRepositorio(ApplicationDbContext context)
    {
        _categoriaContext = context;
    }

    public async Task<Categoria> AtualizarAsync(Categoria categoria)
    {
        _categoriaContext.Update(categoria);
        await _categoriaContext.SaveChangesAsync();
        return categoria;
    }

    public async Task<Categoria> CriarAsync(Categoria categoria)
    {
        _categoriaContext.Add(categoria);
        await _categoriaContext.SaveChangesAsync();
        return categoria;
    }

    public async Task<Categoria> GetById(int? id)
    {
        return await _categoriaContext.Categorias.FindAsync(id);

    }

    public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
    {
        return await _categoriaContext.Categorias.ToListAsync();
    }

    public async Task<Categoria> RemoverAsync(Categoria categoria)
    {
        _categoriaContext.Remove(categoria);
        await _categoriaContext.SaveChangesAsync();
        return categoria;
    }
}

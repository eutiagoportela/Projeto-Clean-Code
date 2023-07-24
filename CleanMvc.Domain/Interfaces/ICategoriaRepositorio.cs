using CleanMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMvc.Domain.Interfaces;

public interface ICategoriaRepositorio
{
    Task<IEnumerable<Categoria>> GetCategoriasAsync();
    Task<Categoria> GetById(int? id);

    Task<Categoria> CriarAsync(Categoria categoria);
    Task<Categoria> AtualizarAsync(Categoria categoria);
    Task<Categoria> RemoverAsync(Categoria categoria);
}

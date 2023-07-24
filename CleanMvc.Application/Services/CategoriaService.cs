

using AutoMapper;
using CleanMvc.Application.DTOs;
using CleanMvc.Application.Interfaces;
using CleanMvc.Domain.Entities;
using CleanMvc.Domain.Interfaces;

namespace CleanMvc.Application.Services;

public class CategoriaService : ICategoriaService
{
    private ICategoriaRepositorio _categoriaRepositorio;
    private readonly IMapper _mapper;   

    public CategoriaService(ICategoriaRepositorio categoriaRepositorio,IMapper mapper) 
    {
       _categoriaRepositorio = categoriaRepositorio;
        _mapper = mapper;
    }

    public async Task<CategoriaDTO> GetById(int? id)
    {
        var categoriaEntities = await _categoriaRepositorio.GetById(id);
        return _mapper.Map<CategoriaDTO>(categoriaEntities);
    }

    public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
    {
        var categoriasEntities = await _categoriaRepositorio.GetCategoriasAsync();

        return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntities);
    }

    public async Task Add(CategoriaDTO categoriaDTO)
    {
        var categoriaEntities = _mapper.Map<Categoria>(categoriaDTO);
        await _categoriaRepositorio.CriarAsync(categoriaEntities);
    }

    public async Task Remove(int? id)
    {
        var categoriaEntities = _categoriaRepositorio.GetById(id).Result;
        await _categoriaRepositorio.RemoverAsync(categoriaEntities);
        
    }

    public async Task Update(CategoriaDTO categoriaDTO)
    {
        var categoriaEntities = _mapper.Map<Categoria>(categoriaDTO);
        await _categoriaRepositorio.AtualizarAsync(categoriaEntities);
    }
}

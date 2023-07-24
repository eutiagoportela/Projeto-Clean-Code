
using AutoMapper;
using CleanMvc.Application.DTOs;
using CleanMvc.Domain.Entities;

namespace CleanMvc.Application.Mappings;

public class DominioToDTOPerfilMapeamento: Profile //tem que adicionar o automapper no projeto
{
    public DominioToDTOPerfilMapeamento()
    {
        CreateMap<Categoria,CategoriaDTO>().ReverseMap();
        CreateMap<Produto, ProdutoDTO>().ReverseMap();
    }
}

using AutoMapper;
using CleanMvc.Application.DTOs;
using CleanMvc.Application.Interfaces;
using CleanMvc.Domain.Entities;
using CleanMvc.Domain.Interfaces;


namespace CleanMvc.Application.Services
{
    public class ProductService : IProdutotService
    {
        private IProdutoRepositorio _produtoRepositorio;

        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IProdutoRepositorio productRepository)
        {
            _produtoRepositorio = productRepository;

            _mapper = mapper;
        }

    

        public async Task<ProdutoDTO> GetById(int? id)
        {
            var productEntity = await _produtoRepositorio.GetById(id);
            return _mapper.Map<ProdutoDTO>(productEntity);
        }

        public async Task<ProdutoDTO> GetProductCategory(int? id)
        {
            var productEntity = await _produtoRepositorio.GetProdutoCategoriaAsync(id);
            return _mapper.Map<ProdutoDTO>(productEntity);
        }

        public async Task Add(ProdutoDTO productDto)
        {
            var productEntity = _mapper.Map<Produto>(productDto);
            await _produtoRepositorio.CriaraAsync(productEntity);
        }

        public async Task Update(ProdutoDTO productDto)
        {

            var productEntity = _mapper.Map<Produto>(productDto);
            await _produtoRepositorio.AtualizarAsync(productEntity);
        }

        public async Task Remove(int? id)
        {
            var productEntity = _produtoRepositorio.GetById(id).Result;
            await _produtoRepositorio.RemoverAsync(productEntity);
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {

                var produtosEntity = await _produtoRepositorio.GetProdutosAsync();
                return _mapper.Map<IEnumerable<ProdutoDTO>>(produtosEntity);
            
        }

        public async Task<ProdutoDTO> GetProdutoCategoria(int? id)
        {
            var produtoEntity = await _produtoRepositorio.GetProdutoCategoriaAsync(id);
            return _mapper.Map<ProdutoDTO>(produtoEntity);
        }
    }
}

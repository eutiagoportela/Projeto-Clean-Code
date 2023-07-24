using CleanMvc.Application.DTOs;
using CleanMvc.Application.Interfaces;
using CleanMvc.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]// Somente Acesso autenticacao Bearer
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutotService _produtotService;
        private readonly ICategoriaService _categoriaService;

        public ProdutosController(IProdutotService produtotService, ICategoriaService categoriaService)
        {
            _produtotService = produtotService;
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
        {
            var produtos = await _produtotService.GetProdutos();
            if (produtos == null)
            {
                return NotFound("Produto não encontrado");
            }
            return Ok(produtos);
        }


        [HttpGet("{id}", Name = "GetProduto")]
        public async Task<ActionResult<ProdutoDTO>> Get(int id)
        {
            var produto = await _produtotService.GetById(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDto)
        {
            if (produtoDto == null)
                return BadRequest("Dados inválidos");

            await _produtotService.Add(produtoDto);

            return new CreatedAtRouteResult("GetProduto",
                new { id = produtoDto.Id }, produtoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProdutoDTO produtoDto)
        {
            if (id != produtoDto.Id)
            {
                return BadRequest("Dados inválidos");
            }

            if (produtoDto == null)
                return BadRequest("Dados inválidos");

            await _produtotService.Update(produtoDto);
            return Ok(produtoDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(int id)
        {
            var produtoDto = await _produtotService.GetById(id);

            if (produtoDto == null)
            {
                return NotFound("Produto não encontrado");
            }

            await _produtotService.Remove(id);

            return Ok(produtoDto);
        }
    }
}

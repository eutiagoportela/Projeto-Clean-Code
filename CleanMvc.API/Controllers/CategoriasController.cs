using CleanMvc.Application.DTOs;
using CleanMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]// Somente Acesso autenticacao Bearer
    public class CategoriasController : ControllerBase //controlerBase Omite o acesso as views, diferente dos controller MVC, assim não tem rota padrão e sim do cabeçalho Route do controoler
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriasController(ICategoriaService categoriaService)//traz a injecao de dependencia 
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categorias = await _categoriaService.GetCategorias();
            if (categorias == null)
            {
                return NotFound("Categorias não encontradas");//retorna 404
            }

            return Ok(categorias);
        }

        [HttpGet("{id:int}",Name = "GetCategoria")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get(int id)
        {
            var categoria = await _categoriaService.GetById(id);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada");//retorna 404
            }

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
                return BadRequest("Dados Inválidos");

            await _categoriaService.Add(categoriaDTO);

            return new CreatedAtRouteResult("GetCategoria",new {id= categoriaDTO.Id },categoriaDTO);

        }

        [HttpPut]
        public async Task<ActionResult> Put(int id,[FromBody] CategoriaDTO categoriaDTO)
        {
            if (id != categoriaDTO.Id) return BadRequest("Id diferente da categoria a ser alterada");
            if (categoriaDTO == null)
                return BadRequest("Dados Inválidos");

            await _categoriaService.Update(categoriaDTO);

            return Ok(categoriaDTO);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id)
        {
            var categoria = await _categoriaService.GetById(id);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada");//retorna 404
            }

            await _categoriaService.Remove(id);
            return Ok(categoria);
        }
    }
}

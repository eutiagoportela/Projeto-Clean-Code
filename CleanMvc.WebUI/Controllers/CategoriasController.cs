using CleanMvc.Application.DTOs;
using CleanMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanMvc.WebUI.Controllers
{
    [Authorize]//significa que todos metodos só podem ser acessados por usuarios autenticados
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriasController(ICategoriaService categoriaService)//traz a injecao de dependencia 
        {
               _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.GetCategorias();
            return View(categorias);
        }

        [HttpGet]
        public IActionResult Criar() 
        { 
           return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CategoriaDTO categoriaDTO)
        {
            if(ModelState.IsValid) //verificacao feita pelo data anatotation da classe DTO
            {
              await _categoriaService.Add(categoriaDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaDTO);
        }

        [HttpGet]
        public async Task<ActionResult> Editar(int? id)
        {
            if (id == null) return NotFound();
            var categoriaDto = await _categoriaService.GetById(id);
            if(categoriaDto == null) return NotFound();

             return View(categoriaDto); 
        }

        [HttpPost]
        public async Task<ActionResult> Editar(CategoriaDTO categoriaDTO)
        {
            if (ModelState.IsValid) //verificacao feita pelo data anatotation da classe DTO
            {
                try
                {
                    await _categoriaService.Update(categoriaDTO);
                }
                catch (Exception ex)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(categoriaDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null) return NotFound();

            var categoriaDTO = await _categoriaService.GetById(id);
            if(categoriaDTO == null) return NotFound(); 
            return View(categoriaDTO);
        }

        [HttpPost,ActionName("Deletar")]//cria outro com nome para não ter dois metodos com mesmo nome e não dar conflito
        public async Task<ActionResult> ConfirmarDelecao(int id)
        {
            await _categoriaService.Remove(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null) return NotFound();

            var categoriaDTO = await _categoriaService.GetById(id);

            if( categoriaDTO == null) return NotFound(); 
            return View(categoriaDTO);
        }
    }
}

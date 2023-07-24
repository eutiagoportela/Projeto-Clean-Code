using CleanMvc.Application.DTOs;
using CleanMvc.Application.Interfaces;
using CleanMvc.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace CleanMvc.WebUI.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutotService _produtotService;
        private readonly ICategoriaService _categoriaService;
        private readonly IWebHostEnvironment _environment;

        public ProdutosController(IProdutotService produtotService, ICategoriaService categoriaService, IWebHostEnvironment webHostEnvironment)
        {
            _produtotService = produtotService;
            _categoriaService = categoriaService;
            _environment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtotService.GetProdutos();
            return View(produtos);
        }

        [HttpGet]
        public async Task<IActionResult> Criar()//passa lista de categorias para dropboxlist
        {
            ViewBag.CategoriaId =
            new SelectList(await _categoriaService.GetCategorias(), "Id", "Nome");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ProdutoDTO produtoDTO)
        {
            if (ModelState.IsValid)
            {
                await _produtotService.Add(produtoDTO);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.CategoriaId =
                            new SelectList(await _categoriaService.GetCategorias(), "Id", "Nome");
            }
            return View(produtoDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return NotFound();
            var productDto = await _produtotService.GetById(id);

            if (productDto == null) return NotFound();

            var categorias = await _categoriaService.GetCategorias();
            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Nome", productDto.CategoriaId);

            return View(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ProdutoDTO produtoDTO)
        {
            if (ModelState.IsValid)
            {
                await _produtotService.Update(produtoDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(produtoDTO);
        }


        [Authorize(Roles ="Admin")]//somente usuarios autenticados Admin
        [HttpGet]
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
                return NotFound();

            var produtoDto = await _produtotService.GetById(id);

            if (produtoDto == null) return NotFound();

            return View(produtoDto);
        }

        [HttpPost(), ActionName("Deletar")]
        public async Task<IActionResult> ConfirmarDelecao(int id)
        {
            await _produtotService.Remove(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null) return NotFound();
            var produtoDto = await _produtotService.GetProdutoCategoria(id);

            if (produtoDto == null) return NotFound();
            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + produtoDto.Imagem);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(produtoDto);
        }

       
    }
}

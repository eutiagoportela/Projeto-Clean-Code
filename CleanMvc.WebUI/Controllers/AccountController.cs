using CleanMvc.Domain.Account;
using CleanMvc.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanMvc.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAutenticacao _autenticacao;
        public AccountController(IAutenticacao autenticacao)
        {
            _autenticacao = autenticacao;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _autenticacao.Autenticar(model.Email, model.Senha);

            if (result)
            {
                if (string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(model.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Tentativa de logar inválida. (a senha deve ser forte).");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegistrarViewModel model)
        {
            var result = await _autenticacao.RegistrarUsuario(model.Email, model.Senha);

            if (result)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Tentativa de cadastro inválida (a senha deve ser forte).");
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _autenticacao.Logout();
            return Redirect("/Account/Login");
        }
    }
}

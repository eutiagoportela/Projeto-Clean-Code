using Microsoft.AspNetCore.Mvc;

namespace CleanMvc.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacidade()
        {
            return View();
        }
    }
}

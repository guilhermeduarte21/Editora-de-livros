using Microsoft.AspNetCore.Mvc;
using Editora.Web.Models.Usuario;

namespace Editora.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel loginViewModel)
        {
            return View(loginViewModel);
        }
    }
}

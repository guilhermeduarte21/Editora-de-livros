using Microsoft.AspNetCore.Mvc;
using Editora.Web.Models.Usuario;
using Microsoft.AspNetCore.Http;
using RestSharp;
using Newtonsoft.Json;
using System;

namespace Editora.Web.Controllers
{
    public class HomeController : Controller
    {
        string _linkApi = "http://localhost:60914/api/";

        public HomeController()
        {

        }

        [HttpGet]
        public IActionResult Index()
        {
            if(!string.IsNullOrWhiteSpace(this.HttpContext.Session.GetString("Token")))
                return Redirect("Livro/Index");

            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel loginViewModel)
        {
            try
            {
                var client = new RestClient();
                var requestToken = new RestRequest(_linkApi + "Usuarios/Token");

                requestToken.AddJsonBody(JsonConvert.SerializeObject(loginViewModel));

                var result = client.Post<TokenResult>(requestToken).Data;


                if (result == null)
                {
                    ModelState.AddModelError(string.Empty, "Login ou senha inválidos");
                    return View(loginViewModel);
                }

                this.HttpContext.Session.SetString("Token", result.Token);

                return Redirect("Livro/Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro, por favor tente mais tarde.");
                return View(loginViewModel);
            }
        }

        public class TokenResult
        {
            public String Token { get; set; }
        }
    }
}

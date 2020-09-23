using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Editora.Web.Models.Livro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using RestSharp;

namespace Editora.Web.Controllers
{
    public class LivroController : Controller
    {
        string _UriAPI = "http://localhost:60914/api/";

        // GET: LivroController
        public IActionResult Index()
        {
            var client = new RestClient();
            var request = new RestRequest(_UriAPI + "Livros");

            request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));

            var response = client.Get<List<LivroViewModel>>(request);

            return View(response.Data);
        }

        // GET: LivroController/Details/5
        public ActionResult Details(Guid id)
        {
            var client = new RestClient();
            var request = new RestRequest(_UriAPI + "Livros/" + id, DataFormat.Json);

            var response = client.Get<LivroViewModel>(request);

            return View(response.Data);
        }

        // GET: LivroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LivroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLivroViewModel createLivroViewModel)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View(createLivroViewModel);

                var client = new RestClient();
                var request = new RestRequest(_UriAPI + "Livros", DataFormat.Json);
                request.AddJsonBody(createLivroViewModel);

                var response = client.Post<CreateLivroViewModel>(request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro, por favor tente mais tarde.");
                return View(createLivroViewModel);
            }
        }

        // GET: LivroController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var client = new RestClient();
            var request = new RestRequest(_UriAPI + "Livros/" + id, DataFormat.Json);

            var response = client.Get<LivroViewModel>(request);

            return View(response.Data);
        }

        // POST: LivroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, LivroViewModel livroViewModel)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View(livroViewModel);

                var client = new RestClient();
                var request = new RestRequest(_UriAPI + "Livros/" + id, DataFormat.Json);
                request.AddJsonBody(livroViewModel);

                var response = client.Put<LivroViewModel>(request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LivroController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var client = new RestClient();
            var request = new RestRequest(_UriAPI + "Livros/" + id, DataFormat.Json);

            var response = client.Get<LivroViewModel>(request);

            return View(response.Data);
        }

        // POST: LivroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, LivroViewModel livroViewModel)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest(_UriAPI + "Livros/" + id, DataFormat.Json);
                request.AddJsonBody(livroViewModel);

                var response = client.Delete<LivroViewModel>(request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

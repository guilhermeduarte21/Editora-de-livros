using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Editora.Web.Models.Autor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Authenticators;

namespace Editora.Web.Controllers
{
    public class AutorController : Controller
    {
        string _linkApi = "http://localhost:60914/api/";

        // GET: AutorController
        public IActionResult Index()
        {
            var client = new RestClient();
            var request = new RestRequest(_linkApi + "Autores", DataFormat.Json);

            //Não esta adicionando o Token no Header Bearer
            request.AddHeader("authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));

            var response = client.Get<List<AutorViewModel>>(request);

            if (response.Data == null)
                response.Data = new List<AutorViewModel>();

            return View(response.Data);
        }

        // GET: AutorController/Details/5
        public ActionResult Details(Guid id)
        {
            var client = new RestClient();
            var request = new RestRequest(_linkApi + "Autores/" + id, DataFormat.Json);

            var response = client.Get<AutorViewModel>(request);

            return View(response.Data);
        }

        // GET: AutorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormAutorViewModel formAutorViewModel)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View(formAutorViewModel);

                var client = new RestClient();
                var request = new RestRequest(_linkApi + "Autores", DataFormat.Json);
                request.AddJsonBody(formAutorViewModel);

                var response = client.Post<FormAutorViewModel>(request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro, por favor tente mais tarde.");
                return View(formAutorViewModel);
            }
        }

        // GET: AutorController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var client = new RestClient();
            var request = new RestRequest(_linkApi + "Autores/" + id, DataFormat.Json);

            var response = client.Get<AutorViewModel>(request);

            return View(response.Data);
        }

        // POST: AutorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, FormAutorViewModel formAutorViewModel)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View(formAutorViewModel);

                var client = new RestClient();
                var request = new RestRequest(_linkApi + "Autores/" + id, DataFormat.Json);
                request.AddJsonBody(formAutorViewModel);

                var response = client.Put<FormAutorViewModel>(request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutorController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var client = new RestClient();
            var request = new RestRequest(_linkApi + "Autores/" + id, DataFormat.Json);

            var response = client.Get<AutorViewModel>(request);

            return View(response.Data);
        }

        // POST: AutorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, AutorViewModel autorViewModel)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest(_linkApi + "Autores/" + id, DataFormat.Json);
                request.AddJsonBody(autorViewModel);

                var response = client.Delete<FormAutorViewModel>(request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

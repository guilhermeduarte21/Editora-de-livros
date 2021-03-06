﻿using System;
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
        private readonly string _UriAPI = "https://localhost:44356/api/";

        // GET: AutorController
        public IActionResult Index()
        {
            var client = new RestClient();
            var request = new RestRequest(_UriAPI + "Autores");

            request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));

            var response = client.Get<List<AutorViewModel>>(request);

            return View(response.Data);
        }

        // GET: AutorController/Details/5
        public ActionResult Details(Guid id)
        {
            var client = new RestClient();
            var request = new RestRequest(_UriAPI + "Autores/" + id, DataFormat.Json);

            request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));

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
                var request = new RestRequest(_UriAPI + "Autores", DataFormat.Json);
                request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));
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
            var request = new RestRequest(_UriAPI + "Autores/" + id, DataFormat.Json);
            request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));
            var response = client.Get<AutorViewModel>(request);

            return View(response.Data);
        }

        // POST: AutorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, AutorViewModel autorViewModel)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View(autorViewModel);

                var client = new RestClient();
                var request = new RestRequest(_UriAPI + "Autores/" + id, DataFormat.Json);
                request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));
                request.AddJsonBody(autorViewModel);

                var response = client.Put<AutorViewModel>(request);

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
            var request = new RestRequest(_UriAPI + "Autores/" + id, DataFormat.Json);
            request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));
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
                var request = new RestRequest(_UriAPI + "Autores/" + id, DataFormat.Json);
                request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));
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

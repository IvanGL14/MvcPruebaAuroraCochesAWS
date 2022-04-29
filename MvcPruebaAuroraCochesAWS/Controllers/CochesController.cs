using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcPruebaAuroraCochesAWS.Models;
using MvcPruebaAuroraCochesAWS.Repositories;
using MvcPruebaAuroraCochesAWS.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPruebaAuroraCochesAWS.Controllers
{
    public class CochesController : Controller
    {
        private RepositoryCoches repo;
        private ServiceAWS service;

        public CochesController(RepositoryCoches repo, ServiceAWS service)
        {
            this.repo = repo;
            this.service = service;
        }

        public IActionResult Index()
        {
            return View(this.repo.GetCoches() );
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int idcoche, string marca, string modelo, string conductor, IFormFile imagen)
        {
            Stream streamImagen = imagen.OpenReadStream();
            await this.service.UploadFilesAsync(streamImagen, imagen.FileName);
            this.repo.InsertCoche(idcoche, marca, modelo, conductor, imagen.FileName);
            string k = "hola";
            return RedirectToAction("Index");
        }
    }
}

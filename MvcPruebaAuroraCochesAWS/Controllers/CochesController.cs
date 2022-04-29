using Microsoft.AspNetCore.Mvc;
using MvcPruebaAuroraCochesAWS.Models;
using MvcPruebaAuroraCochesAWS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPruebaAuroraCochesAWS.Controllers
{
    public class CochesController : Controller
    {
        private RepositoryCoches repo;

        public CochesController(RepositoryCoches repo)
        {
            this.repo = repo;
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
        public IActionResult Create(Coche coche)
        {
            this.repo.InsertCoche(coche.IdCoche, coche.Marca, coche.Modelo, coche.Conductor, coche.Imagen);
            return RedirectToAction("Index");
        }
    }
}

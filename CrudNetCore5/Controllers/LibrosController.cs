using CrudNetCore5.Data;
using CrudNetCore5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore5.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LibrosController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Libro> listaLibros = _db.Libro;
            return View(listaLibros);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            var libro = _db.Libro.Find(id);
            if (libro==null)
            {
                return NotFound();
            }
            return View(libro);
        }

        [HttpPost]
        public IActionResult Create(Libro libro)
        {
            if (ModelState.IsValid) {
                _db.Libro.Add(libro);
                _db.SaveChanges();
                TempData["mensaje"] = "El libro se ha creado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _db.Libro.Update(libro);
                _db.SaveChanges();
                TempData["mensaje"] = "El libro se ha actualizado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var libro = _db.Libro.Find(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }
    }
}

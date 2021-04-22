using HotelFinalProgramacionAvanzada.DataAccess.Repositorio.IRepositorio;
using HotelFinalProgramacionAvanzada.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinalProgramacionAvanzada.Controllers
{
    public class HotelController : Controller
    {
        public HotelController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        readonly IUnidadTrabajo _unidadTrabajo;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upsert(int id = 0)
        {
            if (id == 0)
                return View(new Hotel());
            else
            {
                var t = _unidadTrabajo.Hoteles.Buscar(id);
                if (t == null)
                {
                    return NotFound();
                }
                return View(t);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(int id, Hotel Hotel)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _unidadTrabajo.Hoteles.Agregar(Hotel);
                    _unidadTrabajo.Guardar();
                }
                else
                {
                    try
                    {
                        _unidadTrabajo.Hoteles.Actualizar(Hotel);
                        _unidadTrabajo.Guardar();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (_unidadTrabajo.Hoteles.Buscar(Hotel.HotelId) == null)
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { success = true, message = "El Hotel ha sido guardado." });
            }
            return Json(new { success = false, message = "Ocurrió un error guardando el Hotel." });
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Json(new { success = true, data = _unidadTrabajo.Hoteles.Listar() });
        }

        [HttpDelete]
        public IActionResult Borrar(int id)
        {
            var t = _unidadTrabajo.Hoteles.Buscar(id);
            if (t == null)
            {
                return Json(new { success = false, message = "Hotel no borrado." });
            }
            _unidadTrabajo.Hoteles.Remover(t);
            _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "El Hotel ha sido borrado." });
        }
    }
}

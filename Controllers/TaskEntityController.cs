using EjercitacionMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;

namespace EjercitacionMVC.Controllers
{
    public class TaskEntityController : Controller
    {
        private HrContext _contexto;

        public TaskEntityController(HrContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var listadoTareas = _contexto.TaskItems.ToList();
            return View(listadoTareas);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(TaskItem item)
        {
            if (ModelState.IsValid)
            {
                _contexto.TaskItems.Add(item);
                _contexto.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Eliminar(int pid)
        {
            var item = _contexto.TaskItems.SingleOrDefault(m => m.Id == pid);

            _contexto.TaskItems.Remove(item);

            _contexto.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Actualizar(int pid)
        {
            var item = _contexto.TaskItems.SingleOrDefault(m => m.Id == pid);

            return View(item);
        }


        [HttpPost]
        public IActionResult GuardarActualizacion(TaskItem pitem)
        {
            _contexto.TaskItems.Update(pitem);
            _contexto.SaveChanges();

            return RedirectToAction("Index");
        }

        
    }
}

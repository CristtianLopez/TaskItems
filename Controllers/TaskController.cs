using Microsoft.AspNetCore.Mvc;
using EjercitacionMVC.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Filters;
using EjercitacionMVC.Filters;
using EjercitacionMVC.Services;
using System.Threading.Tasks;


namespace EjercitacionMVC.Controllers
{
    public class TaskController : Controller
    {
        // Lista estática para almacenar las tareas
        private static List<TaskItem> tasks = new List<TaskItem>();

        private static List<TaskV2> tasksV2 = new List<TaskV2>();

        private readonly IFormatNumber formatNumber;

        public TaskController(IFormatNumber miServicio)
        {
            formatNumber = miServicio;
            if (tasksV2.Count == 0)
            {
                TaskV2 taskV2 = new TaskV2
                {
                    Id = 1,
                    Titulo = "Hacer mandados",
                    Descripcion = "Ir a la verduleria a comprar papa",
                    Fecha = DateTime.Now
                };

                TaskV2 taskV22 = new TaskV2
                {
                    Id = 2,
                    Titulo = "Entrenar",
                    Descripcion = "Ir al gimnasio para hacer mi rutina",
                    Fecha = DateTime.Now
                };

                TaskV2 taskV23 = new TaskV2
                {
                    Id = 3,
                    Titulo = "Salir a cenar",
                    Descripcion = "Preparar todo para salir esta noche a comer a MCdonald",
                    Fecha = DateTime.Now
                };

                tasksV2.Add(taskV2);
                tasksV2.Add(taskV22);
                tasksV2.Add(taskV23);
            }
        }

        [ServiceFilter(typeof(FiltrosAccion))]
        public IActionResult Index()
        {
            return View(tasks);
        }

        public IActionResult IndexV2()
        {
            return View(tasksV2);
        }

        public IActionResult CrearV2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearV2(TaskV2 task)
        {
            tasksV2.Add(task);
            return RedirectToAction("IndexV2");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            // Generar un Id simple basado en el conteo de tareas
            task.Id = tasks.Count + 1;
            tasks.Add(task);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            TaskItem item = new TaskItem();
            foreach (TaskItem task in tasks)
            {
                if (task.Id == id)
                {
                    item = task;
                }
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Update(TaskItem item)
        {
            foreach (TaskItem task in tasks)
            {
                if (task.Id == item.Id)
                {
                    task.Title = item.Title;
                    task.Description = item.Description;
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            TaskItem item = new TaskItem();
            foreach (TaskItem task in tasks)
            {
                if (task.Id == id)
                {
                    item = task;
                }
            }

            tasks.Remove(item);

            return RedirectToAction("Index");
        }

    }
}

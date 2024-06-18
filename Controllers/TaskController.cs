using Microsoft.AspNetCore.Mvc;
using EjercitacionMVC.Models;
using System.Collections.Generic;


namespace EjercitacionMVC.Controllers
{
    public class TaskController : Controller
    {
        // Lista estática para almacenar las tareas
        private static List<TaskItem> tasks = new List<TaskItem>();

        public IActionResult Index()
        {
            return View(tasks);
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
        public IActionResult Update(TaskItem item) {
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

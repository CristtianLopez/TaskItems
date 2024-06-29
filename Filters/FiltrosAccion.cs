using Microsoft.AspNetCore.Mvc.Filters;

namespace EjercitacionMVC.Filters
{
    public class FiltrosAccion : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //var actionName = context.ActionDescriptor.DisplayName;
            //var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //System.IO.File.AppendAllText("log.txt", $"Action {actionName} started at {timestamp}\n");

            Console.WriteLine("Inicio Accion");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //var actionName = context.ActionDescriptor.DisplayName;
            //var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //System.IO.File.AppendAllText("log.txt", $"Action {actionName} finished at {timestamp}\n");

            Console.WriteLine("Fin Accion");
        }
    }
}

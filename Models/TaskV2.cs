using System.ComponentModel.DataAnnotations;

namespace EjercitacionMVC.Models
{
    public class TaskV2
    {
        [Required(ErrorMessage ="Por favor, insertar ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, insertar Titulo")]
        [StringLength(30)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Por favor, insertar Descripcion")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Por favor, insertar Fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}

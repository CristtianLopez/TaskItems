using System.ComponentModel.DataAnnotations;

namespace EjercitacionMVC.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }


    }
}

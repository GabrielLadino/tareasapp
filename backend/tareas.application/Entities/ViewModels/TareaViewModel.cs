using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tareas.application.Entities.ViewModels
{
    public class TareaViewModel
    {
        public int Id { get; set; } = 0;

        [Required(ErrorMessage = "Requerido")]
        [MaxLength(256, ErrorMessage = "Largo Maximo")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Requerido")] 
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "Requerido")] 
        public string FechaCreacion { get; set; } = string.Empty;
        public bool Completado { get; set; } = false;
    }
}

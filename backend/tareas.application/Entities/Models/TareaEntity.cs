using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tareas.application.Entities.Models
{
    public class TareaEntity:BaseModel
    {

        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get;set; }=string.Empty;
        public string FechaCreacion { get; set; }=string.Empty;
        public bool Completado { get; set; } = false;
    }
}

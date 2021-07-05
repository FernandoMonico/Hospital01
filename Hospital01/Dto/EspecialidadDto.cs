using Microsoft.Data.SqlClient.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital01.Dto
{
    public class EspecialidadDto
    {
        public int Iidespecialidad { get; set; }
        [Required(ErrorMessage = "El campo 'Nombre' es requirido.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo 'Descripción' es requerido.")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public int? Bhabilitado { get; set; }
    }
}

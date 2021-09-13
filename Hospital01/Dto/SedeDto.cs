using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital01.Dto
{
    public class SedeDto
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Nombre { get; set; }
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Direccion { get; set; }
        public int? Bhabilitado { get; set; }
        public string NombreErrorMessage { get; set; }
    }
}

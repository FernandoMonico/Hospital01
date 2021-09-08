using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital01.Dto
{
    public class TipoUsuarioDto
    {
        [Display(Name = "Identificador Tipo Usuario")]
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Nombre { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(25, ErrorMessage = "Maximo 25 caracteres")]
        public string Descripcion { get; set; }
    }
}

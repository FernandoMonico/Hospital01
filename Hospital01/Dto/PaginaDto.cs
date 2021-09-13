using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital01.Dto
{
    public class PaginaDto
    {
        [DisplayName("Identificador")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo 'Mensaje' es requerido")]
        public string Mensaje { get; set; }
        [DisplayName("Acción")]
        [Required(ErrorMessage = "El campo 'Acción' es requerido")]
        public string Action { get; set; }
        [DisplayName("Controlador")]
        [Required(ErrorMessage = "El campo 'Controller' es requerido")]
        [MinLength(3, ErrorMessage = "Minimo 3 caracteres")]
        [MaxLength(30, ErrorMessage = "Maximo 20 caracteres")]
        public string Controller { get; set; }
        public int? Bhabilitado { get; set; }
        public string MensajeErrorMessage { get; set; }
    }
}

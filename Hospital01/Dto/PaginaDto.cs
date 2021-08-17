using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital01.Dto
{
    public class PaginaDto
    {
        [DisplayName("Identificador")]
        public int Id { get; set; }
        public string Mensaje { get; set; }
        [DisplayName("Acción")]
        public string Action { get; set; }
        [DisplayName("Controlador")]
        public string Controller { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital01.Dto
{
    public class PersonaDto
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string NombreCompleto { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Sexo")]
        public string NombreSexo { get; set; }
        public int SexoId { get; set; }
    }
}

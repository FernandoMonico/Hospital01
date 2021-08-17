using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital01.Dto
{
    public class MedicamentoDto
    {
        [Display(Name="Identificador")]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal? Precio { get; set; }
        public int? Stock { get; set; }
        [Display(Name="Forma Farmaceutica")]
        public string FormaFarmaceutica { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital01.Dto
{
    public class MedicamentoDto
    {
        [Display(Name = "Identificador")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo 'Nombre' es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo 'Precio' es requerido")]
        public decimal? Precio { get; set; }
        [Required(ErrorMessage = "El campo 'Stock' es requerido")]
        [RegularExpression("([0-9]+)")]
        public int? Stock { get; set; }
        [Display(Name="Forma Farmaceutica")]
        public string FormaFarmaceutica { get; set; }
        [Display(Name = "Seleccione Forma Farmaceutica")]
        [Required(ErrorMessage = "El campo 'Forma Farmaceutica' es requerido")]
        public int? FormaFarmaceuticaId { get; set; }

        //Información adicional
        [Display(Name = "Presentación")]
        public string Presentacion { get; set; }
        [Display(Name = "Concentración")]
        public string Concentracion { get; set; }
    }
}

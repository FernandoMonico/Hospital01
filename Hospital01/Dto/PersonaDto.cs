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
        [Required(ErrorMessage = "El campo 'Nombre' es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo 'Apellido Paterno' es requerido")]
        [Display(Name = "Apellio Paterno")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        [Required(ErrorMessage = "El campo 'Apellido Materno' es requerido")]
        public string ApellidoMaterno { get; set; }
        [Display(Name = "Teléfono Fijo")]
        [MaxLength(8, ErrorMessage = "La cantidad maximo de caracteres es 8")]
        [Required(ErrorMessage = "El campo 'Teléfono Fijo' es requerido")]
        public string TelefonoFijo { get; set; }
        [Display(Name = "Telefono Celular")]
        [Required(ErrorMessage = "El campo 'Teléfono Celular' es requerido")]
        public string TelefonoCelular { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha invalido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Campo requerido")]
        public DateTime? FechaNacimiento { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo requerido")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Formato de correo invalido")]
        public string Email { get; set; }
        [Display(Name = "Sexo")]
        public string NombreSexo { get; set; }
        [Display(Name = "Seleccione Sexo")]
        [Required(ErrorMessage = "Campo requerido")]
        public int? SexoId { get; set; }
    }
}

using Hospital01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital01.Dto;

namespace Hospital01.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            List<PersonaDto> personaDtoList = new List<PersonaDto>();
            using (BDHospitalContext db = new BDHospitalContext()) {
                personaDtoList = (from persona in db.Persona
                                  join sexo in db.Sexo on persona.Iidsexo equals sexo.Iidsexo
                                  where persona.Bhabilitado == 1
                                  select new PersonaDto
                                  {
                                      Id = persona.Iidpersona,
                                      Email = persona.Email,
                                      NombreCompleto = string.Format("{0} {1} {2}", persona.Nombre, persona.Appaterno, persona.Apmaterno),
                                      NombreSexo = sexo.Nombre
                                  }).ToList();
            }
                return View(personaDtoList);
        }
    }
}

using Hospital01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital01.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital01.Controllers
{
    public class PersonaController : Controller
    {
        private readonly BDHospitalContext _context;
        public PersonaController(BDHospitalContext context) {
            _context = context;
        }
        public IActionResult Index(PersonaDto personaDto)
        {
            var personaDtoList = new List<PersonaDto>();
            if (personaDto.SexoId > 0)
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
                    personaDtoList = (from persona in db.Persona
                                      join sexo in db.Sexo on persona.Iidsexo equals sexo.Iidsexo
                                      where persona.Bhabilitado == 1 &&
                                      sexo.Iidsexo == personaDto.SexoId
                                      select new PersonaDto
                                      {
                                          Id = persona.Iidpersona,
                                          Email = persona.Email,
                                          NombreCompleto = string.Format("{0} {1} {2}", persona.Nombre, persona.Appaterno, persona.Apmaterno),
                                          NombreSexo = sexo.Nombre
                                      }).ToList();
                }
            }
            else
            {
                using (BDHospitalContext db = new BDHospitalContext())
                {
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
            }
            ViewBag.selectListSexo = GetAllSexo();
            return View(personaDtoList);
        }

        private List<SelectListItem> GetAllSexo() {
            var result = _context.Sexo.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Iidsexo.ToString() }).ToList();
            result.Insert(0, new SelectListItem { Text = "--- Seleccione ---", Value = string.Empty });
            return result;
        }
    }
}

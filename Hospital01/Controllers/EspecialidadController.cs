using AutoMapper;
using Hospital01.Dto;
using Hospital01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital01.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly IMapper mapper;
        public EspecialidadController(IMapper _mapper) {
            mapper = _mapper;
        }
        public IActionResult Index()
        {
            var especialidadDtoList = new List<EspecialidadDto>();
            using (BDHospitalContext db = new BDHospitalContext()) {
                //especialidadDtoList = (from especialidad in db.Especialidad
                //                       where especialidad.Bhabilitado == 1
                //                       select new EspecialidadDto
                //                       {
                //                           Iidespecialidad = especialidad.Iidespecialidad,
                //                           Nombre = especialidad.Nombre,
                //                           Descripcion = especialidad.Descripcion
                //                       }).ToList();
                especialidadDtoList = db.Especialidad.Where(x => x.Bhabilitado == 1).Select(x => mapper.Map<EspecialidadDto>(x)).ToList();
            }
            return View(especialidadDtoList);
        }
    }
}

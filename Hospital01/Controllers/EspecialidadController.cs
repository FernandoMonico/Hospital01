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
        private readonly IMapper _mapper;
        public EspecialidadController(IMapper mapper) {
            _mapper = mapper;
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
                especialidadDtoList = db.Especialidad.Where(x => x.Bhabilitado == 1).Select(x => _mapper.Map<EspecialidadDto>(x)).ToList();
                EspecialidadTestMap1Dto especialidadTestMap1Dto = new EspecialidadTestMap1Dto { Active = true, TestMessage = "Message 1" };
                EspecialidadTestMap2Dto especialidadTestMap2Dto = new EspecialidadTestMap2Dto { Active = true, TestMessage = "Message 2" };
                for(int i = 0; i < especialidadDtoList.Count; i++) {
                    _mapper.Map(especialidadTestMap1Dto, especialidadDtoList[i]);
                    _mapper.Map(especialidadTestMap2Dto, especialidadDtoList[i]);
                }
            }
            return View(especialidadDtoList);
        }
    }
}

using AutoMapper;
using Hospital01.Dto;
using Hospital01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital01.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly IMapper _mapper;
        private readonly BDHospitalContext _context;
        public EspecialidadController(IMapper mapper, BDHospitalContext context) {
            _mapper = mapper;
            _context = context;
        }
        public IActionResult Index(EspecialidadDto especialidadDto) {
            var result = _context.Especialidad.AsNoTracking().AsExpandable();
            if (especialidadDto.Nombre != null && especialidadDto.Nombre != string.Empty) {
                result = result.Where(x => x.Nombre.Contains(especialidadDto.Nombre));
                ViewBag.Nom = especialidadDto.Nombre;
            }
            var especialidadDtoList = result.Select(x => _mapper.Map<EspecialidadDto>(x)).ToList();
            return View(especialidadDtoList);
        }
        public IActionResult Index_2()
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
                for (int i = 0; i < especialidadDtoList.Count; i++) {
                    _mapper.Map(especialidadTestMap1Dto, especialidadDtoList[i]);
                    _mapper.Map(especialidadTestMap2Dto, especialidadDtoList[i]);
                }
            }
            return View(especialidadDtoList);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EspecialidadDto especialidadDto) {
            try
            {
                if (ModelState.IsValid)
                {
                    var especialidad = _mapper.Map<Especialidad>(especialidadDto);
                    especialidad.Bhabilitado = 1;
                    _context.Especialidad.Add(especialidad);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    return View(especialidadDto);
            }
            catch (Exception e)
            {
                return View(especialidadDto);
            }
        }
    }
}

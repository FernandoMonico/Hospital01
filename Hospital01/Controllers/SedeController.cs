using AutoMapper;
using Hospital01.Dto;
using Hospital01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LinqKit;
using Hospital01.Helper;

namespace Hospital01.Controllers
{
    public class SedeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly BDHospitalContext _context;
        public SedeController(IMapper mapper, BDHospitalContext context) {
            _mapper = mapper;
            _context = context;
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SedeDto sedeDto) {
            try
            {
                if (ModelState.IsValid && !ExisteNombreSede(ref sedeDto))
                {
                    var sede = _mapper.Map<Sede>(sedeDto);
                    sede.Bhabilitado = 1;
                    _context.Sede.Add(sede);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                    return View(sedeDto);
            }
            catch
            {
                return NotFound();
            }
        }

        public IActionResult Index(SedeDto sedeDto) {
            var result = _context.Sede.AsNoTracking().AsExpandable().Where(x => x.Bhabilitado == 1);
            if (sedeDto.Nombre != null && sedeDto.Nombre != string.Empty) {
                result = result.Where(x => x.Nombre.Contains(sedeDto.Nombre));
                ViewBag.NombreSede = sedeDto.Nombre;
            }
            var sedeDtoList = result.Select(x => _mapper.Map<SedeDto>(x)).ToList();
            return View(sedeDtoList);
        }

        public IActionResult Index_2()
        {
            List<SedeDto> sedeDtoList = new List<SedeDto>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                sedeDtoList = (from sede in db.Sede
                               where sede.Bhabilitado == 1
                               select _mapper.Map<SedeDto>(sede))
                               .ToList();
            }
            return View(sedeDtoList);
        }
        [HttpPost]
        public IActionResult Delete(int sedeId) {
            try
            {
                if (sedeId > 0)
                {
                    var sede = _context.Sede.FirstOrDefault(x => x.Iidsede == sedeId);
                    sede.Bhabilitado = 0;
                    _context.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id) {
            if (id != null && id > 0)
            {
                var sede = await _context.Sede.FindAsync(id);
                if (sede != null)
                {
                    var sedeDto = _mapper.Map<SedeDto>(sede);
                    return View(sedeDto);
                }
                else
                    return NotFound();
            }
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SedeDto sedeDto) {
            try
            {
                if (ModelState.IsValid && !ExisteNombreSede(ref sedeDto))
                {
                    var sede = _mapper.Map<Sede>(sedeDto);
                    _context.Sede.Update(sede);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                    return View(sedeDto);
            }
            catch
            {
                return NotFound();
            }
        }

        private bool ExisteNombreSede(ref SedeDto sedeDto) {
            var sedeId = sedeDto.Id;
            var sedeNombre = sedeDto.Nombre;
            bool existeNombreSede = _context.Sede.Any(x => x.Iidsede != sedeId && x.Nombre.ToLower() == sedeNombre.ToLower());
            if(existeNombreSede)
                sedeDto.NombreErrorMessage = "El nombre de la sede ya existe";
            return existeNombreSede;
        }
    }
}

using AutoMapper;
using Hospital01.Dto;
using Hospital01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital01.Controllers
{
    public class MedicamentoController : Controller
    {
        private readonly BDHospitalContext _context;
        private readonly IMapper _mapper;
        public MedicamentoController(BDHospitalContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index(MedicamentoDto medicamentoDto)
        {
            var medicamentoDtoList = new List<MedicamentoDto>();
            if (medicamentoDto.FormaFarmaceuticaId > 0)
            {
                medicamentoDtoList = (from medicamento in _context.Medicamento
                                      join formaFarmaceutica in _context.FormaFarmaceutica
                                      on medicamento.Iidformafarmaceutica equals formaFarmaceutica.Iidformafarmaceutica
                                      where medicamento.Iidformafarmaceutica == medicamentoDto.FormaFarmaceuticaId
                                      select new MedicamentoDto
                                      {
                                          Id = medicamento.Iidmedicamento,
                                          Nombre = medicamento.Nombre,
                                          Precio = medicamento.Precio,
                                          Stock = medicamento.Stock,
                                          FormaFarmaceutica = formaFarmaceutica.Nombre
                                      }).ToList();
            }
            else
            {
                medicamentoDtoList = (from medicamento in _context.Medicamento
                                      join formaFarmaceutica in _context.FormaFarmaceutica
                                      on medicamento.Iidformafarmaceutica equals formaFarmaceutica.Iidformafarmaceutica
                                      select new MedicamentoDto
                                      {
                                          Id = medicamento.Iidmedicamento,
                                          Nombre = medicamento.Nombre,
                                          Precio = medicamento.Precio,
                                          Stock = medicamento.Stock,
                                          FormaFarmaceutica = formaFarmaceutica.Nombre
                                      }).ToList();
            }
            
            ViewBag.formaFarmaceuticaList = GetAllFormaFarmaceutica();
            return View(medicamentoDtoList);
        }

        private List<SelectListItem> GetAllFormaFarmaceutica() {
            var result = _context.FormaFarmaceutica.Where(x => x.Bhabilitado == 1)
                .Select(x => new SelectListItem
                {
                    Value = x.Iidformafarmaceutica.ToString(),
                    Text = x.Nombre
                }
                ).ToList();
            result.Insert(0, new SelectListItem { Value = string.Empty, Text = "--- Seleccione ---" });
            return result;
        }

        public IActionResult Create()
        {
            ViewBag.formaFarmaceuticaList = GetAllFormaFarmaceutica();
            return View();
        }
        [HttpPost]
        public IActionResult Create(MedicamentoDto medicamentoDto) {
            if (ModelState.IsValid)
            {
                var medicamento = _mapper.Map<Medicamento>(medicamentoDto);
                medicamento.Bhabilitado = 1;
                _context.Medicamento.Add(medicamento);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.formaFarmaceuticaList = GetAllFormaFarmaceutica();
                return View(medicamentoDto);
            }
        }

        [HttpPost]
        public IActionResult Delete(int medicamentoId) {
            if (medicamentoId > 0) {
                var medicamento = _context.Medicamento.Find(medicamentoId);
                _context.Medicamento.Remove(medicamento);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id) {
            if (id != null && id > 0)
            {
                var medicamento = await _context.Medicamento.FindAsync(id);
                if (medicamento != null)
                {
                    var medicamentoDto = _mapper.Map<MedicamentoDto>(medicamento);
                    ViewBag.formaFarmaceuticaList = GetAllFormaFarmaceutica();
                    return View(medicamentoDto);
                }
                else
                    return NotFound();
            }
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MedicamentoDto medicamentoDto) {
            if (ModelState.IsValid)
            {
                var medicamento = _mapper.Map<Medicamento>(medicamentoDto);
                _context.Update(medicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.formaFarmaceuticaList = GetAllFormaFarmaceutica();
                return View(medicamentoDto);
            }
        }
    }
}

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
    }
}

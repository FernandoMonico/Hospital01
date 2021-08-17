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
    public class MedicamentoController : Controller
    {
        private readonly BDHospitalContext _context;
        private readonly IMapper _mapper;
        public MedicamentoController(BDHospitalContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var medicamentoDtoList = (from medicamento in _context.Medicamento
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
            return View(medicamentoDtoList);
        }
    }
}

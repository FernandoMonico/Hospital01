using AutoMapper;
using Hospital01.Dto;
using Hospital01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hospital01.Controllers
{
    public class PaginaController : Controller
    {
        private readonly BDHospitalContext _context;
        private readonly IMapper _mapper;
        public PaginaController(BDHospitalContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var paginaDtoList = await _context.Pagina.Where(x => x.Bhabilitado.HasValue && x.Bhabilitado == 1).Select(x => _mapper.Map<PaginaDto>(x)).ToListAsync();
            return View(paginaDtoList);
        }
    }
}

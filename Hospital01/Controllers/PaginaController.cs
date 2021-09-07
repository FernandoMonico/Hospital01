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
        public async Task<IActionResult> Index(PaginaDto paginaDto)
        {
            var query = _context.Pagina.AsNoTracking().AsExpandable().Where(x => x.Bhabilitado == 1);
            if (paginaDto.Mensaje != null && paginaDto.Mensaje != string.Empty) {
                query = query.Where(x => x.Mensaje.Contains(paginaDto.Mensaje));
            }
            var paginaDtoList = await query.Select(x => _mapper.Map<PaginaDto>(x)).ToListAsync();
            ViewBag.filtroMensaje = paginaDto.Mensaje;
            return View(paginaDtoList);
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PaginaDto paginaDto) {
            try {
                if (ModelState.IsValid)
                {
                    var pagina = _mapper.Map<Pagina>(paginaDto);
                    pagina.Bhabilitado = 1;
                    _context.Pagina.Add(pagina);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    return View(paginaDto);
            }
            catch (Exception) {
                return View(paginaDto);
            }
        }
    }
}

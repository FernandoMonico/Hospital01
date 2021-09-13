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
                if (ModelState.IsValid && !ExisteMensaje(ref paginaDto))
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
        [HttpPost]
        public IActionResult Delete(int paginaId) {
            if (paginaId > 0) {
                var pagina = _context.Pagina.Find(paginaId);
                _context.Pagina.Remove(pagina);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id) {
            if (id != null && id > 0)
            {
                var pagina = await _context.Pagina.FindAsync(id);
                if (pagina != null)
                {
                    var paginaDto = _mapper.Map<PaginaDto>(pagina);
                    return View(paginaDto);
                }
                else
                    return NotFound();
            }
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PaginaDto paginaDto)
        {
            if (ModelState.IsValid && !ExisteMensaje(ref paginaDto))
            {
                var pagina = _mapper.Map<Pagina>(paginaDto);
                _context.Pagina.Update(pagina);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(paginaDto);
        }

        private bool ExisteMensaje(ref PaginaDto paginaDto) {
            var paginaId = paginaDto.Id;
            var paginaMensaje = paginaDto.Mensaje;
            bool existeMensaje = _context.Pagina.Any(x => x.Iidpagina != paginaId && x.Mensaje.ToLower().Trim() == paginaMensaje.ToLower().Trim());
            if (existeMensaje)
                paginaDto.MensajeErrorMessage = "El mensaje ya existe";
            return existeMensaje;
        }
    }
}

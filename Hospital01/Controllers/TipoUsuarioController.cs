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
    public class TipoUsuarioController : Controller
    {
        private readonly BDHospitalContext _context;
        private readonly IMapper _mapper;
        public TipoUsuarioController(BDHospitalContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index(TipoUsuarioDto tipoUsuarioDto)
        {
            var query = _context.TipoUsuario.AsNoTracking().AsExpandable();
            query = query.Where(x => x.Bhabilitado == 1);
            if (tipoUsuarioDto.Id > 0)
                query = query.Where(x => x.Iidtipousuario == tipoUsuarioDto.Id);
            if (tipoUsuarioDto.Nombre != null && tipoUsuarioDto.Nombre != string.Empty)
                query = query.Where(x => x.Nombre.Contains(tipoUsuarioDto.Nombre));
            if (tipoUsuarioDto.Descripcion != null && tipoUsuarioDto.Descripcion != string.Empty)
                query = query.Where(x => x.Descripcion.Contains(tipoUsuarioDto.Descripcion));
            var tipoUsuarioDtoList = query.Select(x => _mapper.Map<TipoUsuarioDto>(x)).ToList();
            ViewBag.id = tipoUsuarioDto.Id;
            ViewBag.nombre = tipoUsuarioDto.Nombre;
            ViewBag.descripcion = tipoUsuarioDto.Descripcion;
            return View(tipoUsuarioDtoList);
        }
    }
}

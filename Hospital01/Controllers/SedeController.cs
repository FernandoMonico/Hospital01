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
    public class SedeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly BDHospitalContext _context;
        public SedeController(IMapper mapper, BDHospitalContext context) {
            _mapper = mapper;
            _context = context;
        }

        public IActionResult Index(SedeDto sedeDto) {
            var result = _context.Sede.AsNoTracking().AsExpandable();
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
    }
}

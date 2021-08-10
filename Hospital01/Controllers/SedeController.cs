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
    public class SedeController : Controller
    {
        IMapper _mapper;
        public SedeController(IMapper mapper) {
            _mapper = mapper;
        }
        public IActionResult Index()
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

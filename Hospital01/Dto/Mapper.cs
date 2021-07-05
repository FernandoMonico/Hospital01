using AutoMapper;
using Hospital01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital01.Dto
{
    public class Mapper : Profile
    {
        public Mapper() {
            CreateMap<Especialidad, EspecialidadDto>();
        }
    }
}

﻿using AutoMapper;
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
            CreateMap<Especialidad, EspecialidadDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Iidespecialidad));
            CreateMap<EspecialidadTestMap1Dto, EspecialidadDto>()
                .ForMember(x => x.TestMessage1, y => y.MapFrom(z => z.TestMessage));
            CreateMap<EspecialidadTestMap2Dto, EspecialidadDto>()
                .ForMember(x => x.TestMessage2, y => y.MapFrom(z => z.TestMessage));
            CreateMap<Sede, SedeDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Iidsede));
            CreateMap<Pagina, PaginaDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Iidpagina))
                .ForMember(x => x.Action, y => y.MapFrom(z => z.Accion))
                .ForMember(x => x.Controller, y => y.MapFrom(z => z.Controlador));
        }
    }
}

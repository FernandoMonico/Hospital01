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
            CreateMap<Especialidad, EspecialidadDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Iidespecialidad));
            CreateMap<EspecialidadDto, Especialidad>()
                .ForMember(x => x.Iidespecialidad, y => y.MapFrom(z => z.Id));
            CreateMap<EspecialidadTestMap1Dto, EspecialidadDto>()
                .ForMember(x => x.TestMessage1, y => y.MapFrom(z => z.TestMessage));
            CreateMap<EspecialidadTestMap2Dto, EspecialidadDto>()
                .ForMember(x => x.TestMessage2, y => y.MapFrom(z => z.TestMessage));
            CreateMap<Sede, SedeDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Iidsede));
            CreateMap<SedeDto, Sede>()
                .ForMember(x => x.Iidsede, y => y.MapFrom(z => z.Id));
            CreateMap<Pagina, PaginaDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Iidpagina))
                .ForMember(x => x.Action, y => y.MapFrom(z => z.Accion))
                .ForMember(x => x.Controller, y => y.MapFrom(z => z.Controlador));
            CreateMap<PaginaDto, Pagina>()
                .ForMember(x => x.Iidpagina, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Controlador, y => y.MapFrom(z => z.Controller))
                .ForMember(x => x.Accion, y => y.MapFrom(z => z.Action));
            CreateMap<TipoUsuario, TipoUsuarioDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Iidtipousuario));
            CreateMap<TipoUsuarioDto, TipoUsuario>()
                .ForMember(x => x.Iidtipousuario, y => y.MapFrom(z => z.Id));
            CreateMap<MedicamentoDto, Medicamento>()
                .ForMember(x => x.Iidmedicamento, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Iidformafarmaceutica, y => y.MapFrom(z => z.FormaFarmaceuticaId));
            CreateMap<Medicamento, MedicamentoDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Iidformafarmaceutica))
                .ForMember(x => x.FormaFarmaceuticaId, y => y.MapFrom(z => z.Iidformafarmaceutica));
            CreateMap<PersonaDto, Persona>()
                .ForMember(x => x.Appaterno, y => y.MapFrom(z => z.ApellidoPaterno))
                .ForMember(x => x.Apmaterno, y => y.MapFrom(z => z.ApellidoMaterno))
                .ForMember(x => x.Iidsexo, y => y.MapFrom(z => z.SexoId));
        }
    }
}

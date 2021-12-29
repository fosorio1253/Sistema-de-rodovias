using AutoMapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Common.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioExternoViewModel>();
            CreateMap<Usuario, UsuarioInternoViewModel>();
            CreateMap<Perfil, PerfilAcessoViewModel>();
            CreateMap<Grupo, GrupoViewModel>();
            CreateMap<LogAlteracao, LogViewModel>().ForMember(x => x.DataAlteracao, opt => opt.MapFrom(src => ((DateTime)src.DataAlteracao).ToString()));
        }
    }
}
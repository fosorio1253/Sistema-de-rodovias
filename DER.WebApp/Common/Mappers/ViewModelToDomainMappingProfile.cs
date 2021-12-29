using AutoMapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Common.Mappers
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioExternoViewModel, Usuario>();
            CreateMap<UsuarioInternoViewModel, Usuario>();
            CreateMap<PerfilAcessoViewModel, Perfil>();
            CreateMap<GrupoViewModel, Grupo>();
        }
    }
}
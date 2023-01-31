using AutoMapper;
using Labrasa.Application.DTOs;
using LaBrasa.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labrasa.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            
        }
    }
}

using Rgm.ServiceInterfaceLayer.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Rgm.BusinessEntities.Entities;
using Rgm.Domain.Entities.Entities;
using Application.Dto;

namespace Rgm.ServiceLayer.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Aluno_Dto, Aluno_Entity>()
               .ReverseMap();

            CreateMap<TokenDto, TokenEntity>()
               .ReverseMap();
        }
    }
}

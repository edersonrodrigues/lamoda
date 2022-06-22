using Rgm.ServiceInterfaceLayer.Dto;
using AutoMapper;
using Rgm.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rgm.BusinessEntities.Entities;
using Application.Dto;

namespace Rgm.ServiceLayer.Mappings
{
    public class DtoToEntitylProfile : Profile
    {
        public DtoToEntitylProfile()
        {
            CreateMap<Aluno_Entity, Aluno_Dto>()
               .ReverseMap();

            CreateMap<TokenEntity, TokenDto>()
                .ReverseMap();

        }
    }
}

using AutoMapper;
using Hw5CustomMiddlewares.DTOs;
using Hw5CustomMiddlewares.Entities;

namespace Hw5CustomMiddlewares.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Airplane, AirplaneDto>()
                .ForMember(dest => dest.AirplaneAge,
                opt => opt.MapFrom<AirplaneAgeResolver>());
            CreateMap<AirplaneAddDto, Airplane>();
            CreateMap<AirplaneUpdateDto, Airplane>();

        }
    }
}

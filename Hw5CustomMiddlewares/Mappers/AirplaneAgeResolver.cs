using AutoMapper;
using AutoMapper.Execution;
using Hw5CustomMiddlewares.DTOs;
using Hw5CustomMiddlewares.Entities;
using Hw5CustomMiddlewares.Service.Abstract;

namespace Hw5CustomMiddlewares.Mappers
{
    public class AirplaneAgeResolver:IValueResolver<Airplane,AirplaneDto,int>
    {
        private readonly IAirplaneManagerService _service;

        public AirplaneAgeResolver(IAirplaneManagerService service)
        {
            _service = service;
        }

        public int Resolve(Airplane source, AirplaneDto destination, int destMember, ResolutionContext context)
        {
            return _service.GetAirplaneAge(source);
        }
    }
}

using Hw5CustomMiddlewares.Entities;
using Hw5CustomMiddlewares.Models;
using Hw5CustomMiddlewares.Repository.Abstract;
using Hw5CustomMiddlewares.Service.Abstract;

namespace Hw5CustomMiddlewares.Service.Concrete
{
    public class AirplaneManagerService : IAirplaneManagerService
    {

        private readonly IAirplaneManagerRepository _airplaneRepo;

        public AirplaneManagerService(IAirplaneManagerRepository repo)
        {
            _airplaneRepo = repo;
        }

        public async Task<Airplane> AddAsync(Airplane airplane)
        {
            var result = await _airplaneRepo.AddAsync(airplane);
            await _airplaneRepo.SaveChangesAsync();
            return result;
        }

        public async Task<bool> DeleteAsync(Airplane airplane)
        {
            return await _airplaneRepo.DeleteAsync(airplane);
        }

        public async Task<List<Airplane>> GetAsync()
        {
            return await _airplaneRepo.GetAsync();
        }

        public async Task<Airplane?> GetAsync(int id)
        {
            return await _airplaneRepo.GetAsync(id);
        }

        public int GetAirplaneAge(Airplane airplane)
        {
            var age = DateTime.Now.Year - airplane.ManufactureDate.Year;
            return age > 0 ? age : 0;
        }

        public async Task<Airplane> UpdateAsync(Airplane airplane)
        {
            return await _airplaneRepo.UpdateAsync(airplane);
        }

        public async Task<PagedResult<Airplane>> GetAllPagedAsync(int page, int pageSize)
        {
            return await _airplaneRepo.GetAllPagedAsync(page, pageSize);
        }
    }
}

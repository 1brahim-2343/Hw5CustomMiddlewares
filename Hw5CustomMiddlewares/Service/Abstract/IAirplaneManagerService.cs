using Hw5CustomMiddlewares.Entities;
using Hw5CustomMiddlewares.Models;

namespace Hw5CustomMiddlewares.Service.Abstract
{
    public interface IAirplaneManagerService
    {
        Task<List<Airplane>> GetAsync();
        Task<PagedResult<Airplane>> GetAllPagedAsync(int page, int pageSize);
        Task<Airplane?> GetAsync(int id);
        Task<bool> DeleteAsync(Airplane airplane);
        Task<Airplane> AddAsync(Airplane airplane);
        Task<Airplane> UpdateAsync(Airplane airplane);
        int GetAirplaneAge(Airplane airplane);
    }
}

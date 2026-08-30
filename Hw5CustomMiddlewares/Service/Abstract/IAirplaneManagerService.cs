using Hw5CustomMiddlewares.Entities;

namespace Hw5CustomMiddlewares.Service.Abstract
{
    public interface IAirplaneManagerService
    {
        Task<List<Airplane>> GetAsync();
        // add paged result method signature
        Task<Airplane?> GetAsync(int id);
        Task<bool> DeleteAsync(Airplane airplane);
        Task<Airplane> AddAsync(Airplane airplane);
        Task<Airplane> UpdateAsync(Airplane airplane);
        int GetAirplaneAge(Airplane airplane);
    }
}

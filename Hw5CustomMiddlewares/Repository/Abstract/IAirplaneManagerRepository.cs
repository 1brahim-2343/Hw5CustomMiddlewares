using Hw5CustomMiddlewares.Entities;
using Hw5CustomMiddlewares.Models;

namespace Hw5CustomMiddlewares.Repository.Abstract
{
    public interface IAirplaneManagerRepository
    {
        Task<List<Airplane>> GetAsync();
        Task<Airplane?> GetAsync(int id);
        Task<bool> DeleteAsync(Airplane airplane);
        Task<Airplane> UpdateAsync(Airplane airplane);
        Task<Airplane> AddAsync(Airplane airplane);
        Task<bool> SaveChangesAsync();
        Task<PagedResult<Airplane>> GetAllPagedAsync(int page, int pageSize);
    }
}

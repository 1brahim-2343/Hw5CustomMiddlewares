using Hw5CustomMiddlewares.Entities;

namespace Hw5CustomMiddlewares.Repository.Abstract
{
    public interface IAirplaneManagerRepository
    {
        Task<List<Airplane>> GetAsync();
        //add pagedResult method signature
        Task<Airplane?> GetAsync(int id);
        Task<bool> DeleteAsync(Airplane airplane);
        Task<Airplane> UpdateAsync(Airplane airplane);
        Task<Airplane> AddAsync(Airplane airplane);
        Task<bool> SaveChangesAsync();
    }
}

using Hw5CustomMiddlewares.Data;
using Hw5CustomMiddlewares.Entities;
using Hw5CustomMiddlewares.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Hw5CustomMiddlewares.Repository.Concrete
{
    public class AirplaneManagerRepository : IAirplaneManagerRepository
    {
        private readonly AirplaneManagerContext _context;

        public AirplaneManagerRepository(AirplaneManagerContext context)
        {
            _context = context;
        }

        public async Task<Airplane> AddAsync(Airplane airplane)
        {
            var createdAirplane = (await _context.AddAsync(airplane)).Entity;
            return createdAirplane;
        }

        public async Task<bool> DeleteAsync(Airplane airplane)
        {
            _context.Airplanes.Remove(airplane);
            return await SaveChangesAsync();
        }

        public Task<List<Airplane>> GetAsync()
        {
            return _context.Airplanes.ToListAsync();
        }

        public async Task<Airplane?> GetAsync(int id)
        {
            return await _context.Airplanes.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Airplane> UpdateAsync(Airplane airplane)
        {
            var updatedAirplane = _context.Update(airplane).Entity;
            await _context.SaveChangesAsync();
            return updatedAirplane;
        }
    }
}

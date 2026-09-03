using Hw5CustomMiddlewares.Data;
using Hw5CustomMiddlewares.Entities;
using Hw5CustomMiddlewares.Models;
using Hw5CustomMiddlewares.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

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

        public async Task<PagedResult<Airplane>> GetAllPagedAsync(int page, int pageSize)
        {
            var query = _context.Airplanes;

            var totalCount = await query.CountAsync();

            var airplanes = await query
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Airplane>
            {
                items = airplanes,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
            };
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

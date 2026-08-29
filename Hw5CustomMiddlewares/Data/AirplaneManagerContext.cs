using Hw5CustomMiddlewares.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hw5CustomMiddlewares.Data
{
    public class AirplaneManagerContext : DbContext
    {
        public AirplaneManagerContext(DbContextOptions<AirplaneManagerContext> options)
            : base(options)
        {
        }
        public DbSet<Airplane> Airplanes { get; set; }
    }
}

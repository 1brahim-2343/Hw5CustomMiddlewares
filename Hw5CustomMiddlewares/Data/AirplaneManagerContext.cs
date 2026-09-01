using Hw5CustomMiddlewares.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hw5CustomMiddlewares.Data
{
    public class AirplaneManagerContext : IdentityDbContext<ApplicationUser>
    {
        public AirplaneManagerContext(DbContextOptions<AirplaneManagerContext> options)
            : base(options)
        {
        }
        public DbSet<Airplane> Airplanes { get; set; }
    }
}

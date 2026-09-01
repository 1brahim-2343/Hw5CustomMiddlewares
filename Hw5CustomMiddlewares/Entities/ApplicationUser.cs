using Microsoft.AspNetCore.Identity;

namespace Hw5CustomMiddlewares.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string Fullname { get; set; }
    }
}

using Doccure.IdentityService.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Doccure.IdentityService.Context
{
    public class DoccureContext : IdentityDbContext<AppUser>
    {
        public DoccureContext(DbContextOptions<IdentityDbContext> options): base(options)
        {
        }
    }
}

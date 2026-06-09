using Doccure.PharmacyService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.PharmacyService.Context
{
    public class PharmacyContext : DbContext
    {
        public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options)
        {

        }
        public DbSet<Medicine> Medicines { get; set; }
    }
}

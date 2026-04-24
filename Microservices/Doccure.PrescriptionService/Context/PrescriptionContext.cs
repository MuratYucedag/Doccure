using Doccure.PrescriptionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.PrescriptionService.Context
{
    public class PrescriptionContext : DbContext
    {
        public PrescriptionContext(DbContextOptions<PrescriptionContext> options) : base(options)
        {
        }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
    }
}

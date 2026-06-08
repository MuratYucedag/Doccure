using Doccure.QueueService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.QueueService.Context
{
    public class QueueContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-R7AR1ND;initial catalog=DoccureQueueDb;integrated security=true;");
        }
        public DbSet<PatientQueue> PatientQueues { get; set; }
    }
}

using Doccure.PatientService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.PatientService.Context
{
    public class PatientContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-R7AR1ND;initial catalog=DoccurePatientDb;integrated security=true;");
        }
        public DbSet<Patient> Patients { get; set; }
    }
}

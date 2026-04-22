using Doccure.AppointmentService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.AppointmentService.Context
{
    public class AppointmentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-R7AR1ND;initial catalog=DoccureAppointmentDb;integrated security=true;");
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentDetail> AppointmentDetails { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
    }
}

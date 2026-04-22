namespace Doccure.AppointmentService.Entities
{
    public class DoctorSchedule
    {
        public int DoctorScheduleId { get; set; }

        // 🔗 Hangi doktora ait
        public string DoctorId { get; set; }

        // 📅 Gün bilgisi
        public DateTime Date { get; set; }

        // ⏰ Saat bilgisi
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        // ✅ Slot durumu
        public bool IsAvailable { get; set; }

        // 🔗 Eğer doluysa hangi randevu aldı
        public int? AppointmentId { get; set; }
        public Appointment Appointment { get; set; } // 🔥 navigation
    }
}

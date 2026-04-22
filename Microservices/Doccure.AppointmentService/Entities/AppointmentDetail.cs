namespace Doccure.AppointmentService.Entities
{
    public class AppointmentDetail
    {
        public int AppointmentDetailId { get; set; }
        public int AppointmentId { get; set; }

        // 🧠 Hasta tarafı
        public string Complaint { get; set; }       // Şikayet
        public string Notes { get; set; }           // Doktor notu

        // 💊 Medikal taraf
        public string Diagnosis { get; set; }       // Teşhis
        public string Prescription { get; set; }    // Reçete

        // 📅 Süreç
        public bool IsFirstVisit { get; set; }
        public DateTime? CompletedDate { get; set; }
        public Appointment Appointment { get; set; } // 🔥 navigation
    }
}

namespace Doccure.PrescriptionService.Entities
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public int AppointmentId { get; set; } // SQL service
        public string DoctorId { get; set; }   // Mongo
        public string PatientId { get; set; }  // Identity
        public DateTime CreatedDate { get; set; }
        public List<PrescriptionItem> PrescriptionItems { get; set; }
    }
}

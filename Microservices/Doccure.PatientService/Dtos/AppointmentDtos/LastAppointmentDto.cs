namespace Doccure.PatientService.Dtos.AppointmentDtos
{
    public class LastAppointmentDto
    {
        public int AppointmentId { get; set; }
        public string DoctorId { get; set; }
        public string BranchId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Diagnosis { get; set; }
        public string Status { get; set; }
    }
}

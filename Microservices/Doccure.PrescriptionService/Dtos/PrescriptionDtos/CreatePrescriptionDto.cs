namespace Doccure.PrescriptionService.Dtos.PrescriptionDtos
{
    public class CreatePrescriptionDto
    {
        public int AppointmentId { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public List<PrescriptionItemDto> PrescriptionItems { get; set; }
    }
}

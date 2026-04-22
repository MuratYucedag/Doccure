namespace Doccure.AppointmentService.Dtos.AppointmentDetail
{
    public class UpdateAppointmentDetailDto
    {
        public int AppointmentDetailId { get; set; }
        public string Complaint { get; set; }
        public string Notes { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
    }
}

namespace Doccure.AppointmentService.Dtos.AppointmentDetail
{
    public class CreateAppointmentDetailDto
    {
        public int AppointmentId { get; set; }
        public string Complaint { get; set; }
        public string Notes { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public bool IsFirstVisit { get; set; }
    }
}

namespace Doccure.AppointmentService.Dtos.AppointmentDetail
{
    public class ResultAppointmentDetailDto
    {
        public int AppointmentDetailId { get; set; }
        public int AppointmentId { get; set; }
        public string Complaint { get; set; }
        public string Notes { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public bool IsFirstVisit { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}

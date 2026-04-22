namespace Doccure.AppointmentService.Dtos.AppointmentDtos
{
    public class ResultAppointmentDto
    {
        public int AppointmentId { get; set; }
        public string DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
    }
}

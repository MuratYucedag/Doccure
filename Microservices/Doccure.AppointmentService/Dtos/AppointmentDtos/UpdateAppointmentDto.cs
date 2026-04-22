namespace Doccure.AppointmentService.Dtos.AppointmentDtos
{
    public class UpdateAppointmentDto
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
    }
}

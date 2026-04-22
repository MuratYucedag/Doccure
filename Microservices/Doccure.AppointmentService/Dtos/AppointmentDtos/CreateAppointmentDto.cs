namespace Doccure.AppointmentService.Dtos.AppointmentDtos
{
    public class CreateAppointmentDto
    {
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal Price { get; set; }
    }
}

namespace Doccure.WebUI.Dtos.QueueDtos
{
    public class ResultPatientQueueDto
    {
        public int PatientQueueId { get; set; }
        public string PatientName { get; set; }
        public int QueueNumber { get; set; }
        public string Status { get; set; }
        public string BranchName { get; set; }
        public string AppointmentTime { get; set; }
    }
}

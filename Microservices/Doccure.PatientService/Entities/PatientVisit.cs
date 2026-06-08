namespace Doccure.PatientService.Entities
{
    public class PatientVisit
    {
        public Guid PatientVisitId { get; set; }

        public int PatientId { get; set; }

        public DateTime VisitDate { get; set; }

        public string VisitNote { get; set; }

        public Guid DoctorId { get; set; }
    }
}

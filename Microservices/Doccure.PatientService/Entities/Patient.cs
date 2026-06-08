namespace Doccure.PatientService.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string AppUserId { get; set; }
        public string TcKimlikNo { get; set; }
        public string InsuranceType { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}

namespace Doccure.PrescriptionService.Entities
{
    public class PrescriptionItem
    {
        public int PrescriptionItemId { get; set; }
        public string MedicineName { get; set; }
        public string Usage { get; set; }      // günde 2 kez
        public string Duration { get; set; }   // 5 gün
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

    }
}

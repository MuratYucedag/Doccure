namespace Doccure.PharmacyService.Dtos.MedicineDtos
{
    public class ResultMedicineDto
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string Barcode { get; set; }
        public int Stock { get; set; }
        public int CriticalStockLevel { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Status { get; set; }
    }
}

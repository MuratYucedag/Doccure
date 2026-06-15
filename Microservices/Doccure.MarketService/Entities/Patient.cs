namespace Doccure.MarketService.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BlockNo { get; set; }
        public string FloorNo { get; set; }
        public string RoomNo { get; set; }
        public string BedNo { get; set; }
        public bool Status { get; set; }
    }
}

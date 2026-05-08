namespace Doccure.WebUI.Dtos.BranchDtos
{
    public class GetByIdBranchDto
    {
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public string BranchCode { get; set; }
        public int DoctorCount { get; set; }
        public int MonthlyAppointmentCount { get; set; }
        public int BedCount { get; set; }
        public decimal Rating { get; set; }
        public int OccupancyRate { get; set; }
        public string ThemeColor { get; set; }
    }
}

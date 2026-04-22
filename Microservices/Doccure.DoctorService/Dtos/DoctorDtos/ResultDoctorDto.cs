namespace Doccure.DoctorService.Dtos.DoctorDtos
{
    public class ResultDoctorDto
    {
        public string DoctorId { get; set; }
        public string FullName => Name + " " + Surname;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BranchId { get; set; }
        public string ImageUrl { get; set; }
        public int ExperienceYear { get; set; }
        public decimal PricePerHour { get; set; }
    }
}

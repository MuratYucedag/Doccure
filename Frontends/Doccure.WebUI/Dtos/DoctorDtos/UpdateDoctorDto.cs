namespace Doccure.WebUI.Dtos.DoctorDtos
{
    public class UpdateDoctorDto
    {
        public string DoctorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BranchId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public string About { get; set; }
        public int ExperienceYear { get; set; }
        public decimal PricePerHour { get; set; }
        public bool Status { get; set; }
        public List<EducationDto> Educations { get; set; }
        public List<ExperienceDto> Experiences { get; set; }
        public List<AwardDto> Awards { get; set; }
        public List<string> Services { get; set; }
        public List<string> Specializations { get; set; }
        public List<LocationDto> Locations { get; set; }
    }
}

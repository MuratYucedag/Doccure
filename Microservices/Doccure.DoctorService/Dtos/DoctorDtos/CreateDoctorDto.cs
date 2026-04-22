using Doccure.DoctorService.Entities;

namespace Doccure.DoctorService.Dtos.DoctorDtos
{
    public class CreateDoctorDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BranchId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public string About { get; set; }
        public int ExperienceYear { get; set; }
        public decimal PricePerHour { get; set; }
        public List<EducationDto> Educations { get; set; }
        public List<ExperienceDto> Experiences { get; set; }
        public List<AwardDto> Awards { get; set; }
        public List<LocationDto> Locations { get; set; }
        public List<string> Services { get; set; }
        public List<string> Specializations { get; set; }
    }
}

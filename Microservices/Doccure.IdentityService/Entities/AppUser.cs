using Microsoft.AspNetCore.Identity;

namespace Doccure.IdentityService.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? ImageUrl { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }
        public string? BloodGroup { get; set; }
    }
}

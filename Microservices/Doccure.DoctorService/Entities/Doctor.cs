using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Doccure.DoctorService.Entities
{
    public class Doctor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
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

        // 🔥 Sub Collections
        public List<Education> Educations { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<Award> Awards { get; set; }
        public List<string> Services { get; set; }
        public List<string> Specializations { get; set; }
        public List<Location> Locations { get; set; }
    }
}

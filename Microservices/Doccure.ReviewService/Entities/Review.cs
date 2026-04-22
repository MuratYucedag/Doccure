using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Doccure.ReviewService.Entities
{
    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ReviewId { get; set; }
        public string DoctorId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserImageUrl { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public bool Recommend { get; set; }
        public int LikeCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}

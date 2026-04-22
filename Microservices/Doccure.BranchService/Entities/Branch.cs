using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Doccure.BranchService.Entities
{
    public class Branch
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}

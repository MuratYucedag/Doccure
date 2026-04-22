namespace Doccure.ReviewService.Dtos.ReviewDtos
{
    public class CreateReviewDto
    {
        public string DoctorId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserImageUrl { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public bool Recommend { get; set; }
    }
}

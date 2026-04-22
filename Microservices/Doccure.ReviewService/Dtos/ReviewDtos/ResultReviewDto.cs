namespace Doccure.ReviewService.Dtos.ReviewDtos
{
    public class ResultReviewDto
    {
        public string ReviewId { get; set; }
        public string DoctorId { get; set; }
        public string UserName { get; set; }
        public string UserImageUrl { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public bool Recommend { get; set; }
        public int LikeCount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

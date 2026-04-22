using AutoMapper;
using Doccure.ReviewService.Dtos.ReviewDtos;
using Doccure.ReviewService.Entities;

namespace Doccure.ReviewService.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Review, CreateReviewDto>().ReverseMap();
            CreateMap<Review, ResultReviewDto>().ReverseMap();
            CreateMap<Review, GetByIdReviewDto>().ReverseMap();
        }
    }
}

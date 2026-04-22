using AutoMapper;
using Doccure.BranchService.Dtos.BranchDtos;
using Doccure.BranchService.Entities;

namespace Doccure.BranchService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Branch, ResultBranchDto>().ReverseMap();
            CreateMap<Branch, CreateBranchDto>().ReverseMap();
            CreateMap<Branch, UpdateBranchDto>().ReverseMap();
            CreateMap<Branch, GetBranchByIdDto>().ReverseMap();
        }
    }
}

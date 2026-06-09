using AutoMapper;
using Doccure.PharmacyService.Dtos.MedicineDtos;
using Doccure.PharmacyService.Entities;

namespace Doccure.PharmacyService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Medicine, ResultMedicineDto>().ReverseMap();
            CreateMap<Medicine, CreateMedicineDto>().ReverseMap();
            CreateMap<Medicine, UpdateMedicineDto>().ReverseMap();
            CreateMap<Medicine, GetByIdMedicineDto>().ReverseMap();
        }
    }
}

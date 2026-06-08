using AutoMapper;
using Doccure.PatientService.Dtos.PatientDtos;
using Doccure.PatientService.Entities;

namespace Doccure.PatientService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Patient, ResultPatientDto>().ReverseMap();
        }
    }
}

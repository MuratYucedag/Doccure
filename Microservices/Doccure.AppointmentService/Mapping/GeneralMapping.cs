using AutoMapper;
using Doccure.AppointmentService.Dtos.AppointmentDetail;
using Doccure.AppointmentService.Dtos.AppointmentDtos;
using Doccure.AppointmentService.Entities;

namespace Doccure.AppointmentService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Appointment, ResultAppointmentDto>().ReverseMap();
            CreateMap<Appointment, CreateAppointmentDto>().ReverseMap();
            CreateMap<Appointment, UpdateAppointmentDto>().ReverseMap();
            CreateMap<Appointment, GetAppointmentByIdDto>().ReverseMap();

            CreateMap<AppointmentDetail, ResultAppointmentDetailDto>().ReverseMap();
            CreateMap<AppointmentDetail, CreateAppointmentDetailDto>().ReverseMap();
            CreateMap<AppointmentDetail, UpdateAppointmentDetailDto>().ReverseMap();
            CreateMap<AppointmentDetail, GetByIdAppointmentDetailDto>().ReverseMap();
        }
    }
}

using Doccure.AppointmentService.Dtos.AppointmentDetail;

namespace Doccure.AppointmentService.Services.AppointmentDetailServices
{
    public interface IAppointmentDetailService
    {
        Task CreateAsync(CreateAppointmentDetailDto dto);
        Task<ResultAppointmentDetailDto> GetByAppointmentIdAsync(int appointmentId);
        Task UpdateAsync(UpdateAppointmentDetailDto dto);
    }
}

using Doccure.AppointmentService.Dtos.AppointmentDtos;
using Doccure.AppointmentService.Entities;

namespace Doccure.AppointmentService.Services.AppointmentServices
{
    public interface IAppointmentService
    {
        Task<List<ResultAppointmentDto>> GetAllAsync();
        Task<GetAppointmentByIdDto> GetByIdAsync(int id);
        Task CreateAsync(CreateAppointmentDto dto);
        Task UpdateAsync(UpdateAppointmentDto dto);
        Task DeleteAsync(int id);
        Task<LastAppointmentDto> GetLastAppointmentByPatientIdAsync(string patientId);
    }
}

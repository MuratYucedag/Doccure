using Doccure.PrescriptionService.Dtos.PrescriptionDtos;

namespace Doccure.PrescriptionService.Services.PrescriptionService
{
    public interface IPrescriptionService
    {
        Task CreateAsync(CreatePrescriptionDto dto);
        Task<ResultPrescriptionDto> GetByAppointmentIdAsync(int appointmentId);
        Task<List<ResultPrescriptionDto>> GetByPatientIdAsync(string patientId);
        Task<ResultPrescriptionDto> GetByIdAsync(int id);
    }
}

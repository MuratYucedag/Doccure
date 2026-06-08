using AutoMapper;
using Doccure.PatientService.Context;
using Doccure.PatientService.Dtos.AppointmentDtos;
using Doccure.PatientService.Dtos.DoctorDtos;
using Doccure.PatientService.Dtos.IdentityDtos;
using Doccure.PatientService.Dtos.PatientDtos;
using Microsoft.EntityFrameworkCore;

namespace Doccure.PatientService.Services.PatientServices
{
    public class PatientService : IPatientService
    {
        private readonly IMapper _mapper;
        private readonly PatientContext _context;
        private readonly HttpClient _httpClient;
        public PatientService(IMapper mapper, PatientContext context, HttpClient httpClient)
        {
            _mapper = mapper;
            _context = context;
            _httpClient = httpClient;
        }
        public async Task<List<ResultPatientDto>> GetAllPatientsAsync()
        {
            var patients = await _context.Patients.ToListAsync();

            var result = new List<ResultPatientDto>();

            foreach (var patient in patients)
            {
                // IDENTITY
                var identityUser = await _httpClient
                    .GetFromJsonAsync<IdentityUserDto>(
                        $"https://localhost:7225/api/users/{patient.AppUserId}");

                // LAST APPOINTMENT
                var lastAppointment = await _httpClient
                    .GetFromJsonAsync<LastAppointmentDto>(
                        $"https://localhost:7267/api/appointments/patient/{patient.AppUserId}/last");

                DoctorSummaryDto doctor = null;

                // DOCTOR + BRANCH
                if (lastAppointment != null &&
                    !string.IsNullOrEmpty(lastAppointment.DoctorId))
                {
                    doctor = await _httpClient
                        .GetFromJsonAsync<DoctorSummaryDto>(
                            $"https://localhost:7002/api/doctors/{lastAppointment.DoctorId}/summary");
                }

                var dto = new ResultPatientDto
                {
                    PatientId = patient.PatientId,
                    AppUserId = patient.AppUserId,
                    TcKimlikNo = patient.TcKimlikNo,
                    InsuranceType = patient.InsuranceType,
                    CreatedDate = patient.CreatedDate,
                    Status = patient.Status,

                    // IDENTITY
                    Name = identityUser?.Name,
                    Surname = identityUser?.Surname,
                    FullName = $"{identityUser?.Name} {identityUser?.Surname}",
                    Email = identityUser?.Email,
                    PhoneNumber = identityUser?.PhoneNumber,
                    Gender = identityUser?.Gender,
                    BirthDate = identityUser?.BirthDate,
                    BloodGroup = identityUser?.BloodGroup,
                    ImageUrl = identityUser?.ImageUrl,
                    City = identityUser?.City,
                    Address = identityUser?.Address,

                    // APPOINTMENT
                    LastVisitDate = lastAppointment?.AppointmentDate,
                    CurrentDiagnosis = lastAppointment?.Diagnosis,

                    // DOCTOR
                    DoctorId = doctor?.DoctorId,
                    DoctorName = doctor != null
                        ? $"{doctor.Name} {doctor.Surname}"
                        : null,

                    // BRANCH
                    BranchId = doctor?.BranchId,
                    BranchName = doctor?.BranchName
                };

                result.Add(dto);
            }

            return result;
        }
    }
}

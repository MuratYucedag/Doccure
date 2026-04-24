using AutoMapper;
using Doccure.PrescriptionService.Context;
using Doccure.PrescriptionService.Dtos.PrescriptionDtos;
using Doccure.PrescriptionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.PrescriptionService.Services.PrescriptionService
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IMapper _mapper;
        private readonly PrescriptionContext _context;
        public PrescriptionService(IMapper mapper, PrescriptionContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task CreateAsync(CreatePrescriptionDto dto)
        {
            var entity = new Prescription
            {
                AppointmentId = dto.AppointmentId,
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,
                CreatedDate = DateTime.UtcNow,

                PrescriptionItems = dto.PrescriptionItems.Select(x => new PrescriptionItem
                {
                    MedicineName = x.MedicineName,
                    Usage = x.Usage,
                    Duration = x.Duration
                }).ToList()
            };

            await _context.Prescriptions.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ResultPrescriptionDto> GetByAppointmentIdAsync(int appointmentId)
        {
            var value = await _context.Prescriptions
                .Include(x => x.PrescriptionItems)
                .FirstOrDefaultAsync(x => x.AppointmentId == appointmentId);

            return _mapper.Map<ResultPrescriptionDto>(value);
        }

        public async Task<ResultPrescriptionDto> GetByIdAsync(int id)
        {
            var value = await _context.Prescriptions
              .Include(x => x.PrescriptionItems)
              .FirstOrDefaultAsync(x => x.PrescriptionId == id);

            return _mapper.Map<ResultPrescriptionDto>(value);
        }

        public async Task<List<ResultPrescriptionDto>> GetByPatientIdAsync(string patientId)
        {
            var values = await _context.Prescriptions
                .Include(x => x.PrescriptionItems)
                .Where(x => x.PatientId == patientId)
                .ToListAsync();

            return _mapper.Map<List<ResultPrescriptionDto>>(values);
        }
    }
}

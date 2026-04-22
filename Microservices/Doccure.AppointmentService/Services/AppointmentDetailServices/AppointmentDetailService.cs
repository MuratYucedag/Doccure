using AutoMapper;
using Doccure.AppointmentService.Context;
using Doccure.AppointmentService.Dtos.AppointmentDetail;
using Doccure.AppointmentService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.AppointmentService.Services.AppointmentDetailServices
{
    public class AppointmentDetailService : IAppointmentDetailService
    {
        private readonly AppointmentContext _context;
        private readonly IMapper _mapper;
        public AppointmentDetailService(AppointmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateAppointmentDetailDto dto)
        {
            var value = _mapper.Map<AppointmentDetail>(dto);
            value.CompletedDate = DateTime.Now;
            await _context.AppointmentDetails.AddAsync(value);
            var appointment = await _context.Appointments.FirstOrDefaultAsync(x => x.AppointmentId == dto.AppointmentId);
            await _context.SaveChangesAsync();
        }
        public async Task<ResultAppointmentDetailDto> GetByAppointmentIdAsync(int appointmentId)
        {
            var value = await _context.AppointmentDetails.FirstOrDefaultAsync(x => x.AppointmentId == appointmentId);
            return _mapper.Map<ResultAppointmentDetailDto>(value);
        }
        public async Task UpdateAsync(UpdateAppointmentDetailDto dto)
        {
            var value = await _context.AppointmentDetails
               .FirstOrDefaultAsync(x => x.AppointmentDetailId == dto.AppointmentDetailId);

            if (value == null)
                return;

            value.Complaint = dto.Complaint;
            value.Notes = dto.Notes;
            value.Diagnosis = dto.Diagnosis;
            value.Prescription = dto.Prescription;

            _context.AppointmentDetails.Update(value);
            await _context.SaveChangesAsync();
        }
    }
}

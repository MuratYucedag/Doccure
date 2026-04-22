using AutoMapper;
using Doccure.AppointmentService.Context;
using Doccure.AppointmentService.Dtos.AppointmentDtos;
using Doccure.AppointmentService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.AppointmentService.Services.AppointmentServices
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly AppointmentContext _context;
        public AppointmentService(IMapper mapper, AppointmentContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task CreateAsync(CreateAppointmentDto dto)
        {
            var value = _mapper.Map<Appointment>(dto);
            value.Status = "Pending";
            await _context.Appointments.AddAsync(value);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var value = await _context.Appointments.FindAsync(id);
            _context.Appointments.Remove(value);
            await _context.SaveChangesAsync();
        }
        public async Task<List<ResultAppointmentDto>> GetAllAsync()
        {
            var values = await _context.Appointments.ToListAsync();
            return _mapper.Map<List<ResultAppointmentDto>>(values);
        }
        public async Task<GetAppointmentByIdDto> GetByIdAsync(int id)
        {
            var value = await _context.Appointments.FindAsync(id);
            return _mapper.Map<GetAppointmentByIdDto>(value);
        }
        public async Task UpdateAsync(UpdateAppointmentDto dto)
        {
            var value = await _context.Appointments.FindAsync(dto.AppointmentId);
            _context.Appointments.Update(value);
            await _context.SaveChangesAsync();
        }
    }
}

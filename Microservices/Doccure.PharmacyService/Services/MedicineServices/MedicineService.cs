using AutoMapper;
using Doccure.PharmacyService.Context;
using Doccure.PharmacyService.Dtos.MedicineDtos;
using Doccure.PharmacyService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.PharmacyService.Services.MedicineServices
{
    public class MedicineService : IMedicineService
    {
        private readonly PharmacyContext _context;
        private readonly IMapper _mapper;

        public MedicineService(PharmacyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ResultMedicineDto>> GetAllMedicineAsync()
        {
            var values = await _context.Medicines.ToListAsync();
            return _mapper.Map<List<ResultMedicineDto>>(values);
        }

        public async Task<GetByIdMedicineDto> GetByIdMedicineAsync(int id)
        {
            var value = await _context.Medicines.FindAsync(id);
            return _mapper.Map<GetByIdMedicineDto>(value);
        }

        public async Task CreateMedicineAsync(CreateMedicineDto createMedicineDto)
        {
            var value = _mapper.Map<Medicine>(createMedicineDto);
            await _context.Medicines.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMedicineAsync(UpdateMedicineDto updateMedicineDto)
        {
            var value = await _context.Medicines.FirstOrDefaultAsync(x => x.MedicineId == updateMedicineDto.MedicineId);
            _mapper.Map(updateMedicineDto, value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMedicineAsync(int id)
        {
            var value = await _context.Medicines.FindAsync(id);
            _context.Medicines.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}

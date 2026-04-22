using AutoMapper;
using Doccure.BranchService.Dtos.BranchDtos;
using Doccure.BranchService.Entities;
using Doccure.BranchService.Settings;
using MongoDB.Driver;

namespace Doccure.BranchService.Services
{
    public class BranchService : IBranchService
    {
        private readonly IMongoCollection<Branch> _branchCollection;
        private readonly IMapper _mapper;
        public BranchService(IMapper mapper, IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _branchCollection = database.GetCollection<Branch>(settings.BranchCollectionName);
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateBranchDto dto)
        {
            var value = _mapper.Map<Branch>(dto);
            await _branchCollection.InsertOneAsync(value);
        }
        public async Task DeleteAsync(string id)
        {
            await _branchCollection.DeleteOneAsync(x => x.BranchId == id);
        }
        public async Task<List<ResultBranchDto>> GetAllAsync()
        {
            var values = await _branchCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBranchDto>>(values);
        }
        public async Task<GetBranchByIdDto> GetByIdAsync(string id)
        {
            var value = await _branchCollection.Find(x => x.BranchId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetBranchByIdDto>(value);
        }
        public async Task UpdateAsync(UpdateBranchDto dto)
        {
            var value = _mapper.Map<Branch>(dto);
            await _branchCollection.FindOneAndReplaceAsync(x => x.BranchId == dto.BranchId, value);
        }
    }
}

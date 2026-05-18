using Doccure.BranchService.Dtos.BranchDtos;
using Doccure.BranchService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.BranchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> BrachList()
        {
            var values = await _branchService.GetAllAsync();
            return Ok(values);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateBranch(CreateBranchDto createBranchDto)
        {
            await _branchService.CreateAsync(createBranchDto);
            return Ok("Ekleme başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBranch(string id)
        {
            await _branchService.DeleteAsync(id);
            return Ok("Silme başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBranch(UpdateBranchDto updateBranchDto)
        {
            await _branchService.UpdateAsync(updateBranchDto);
            return Ok("Güncelleme başarılı");
        }

        [HttpGet("GetBranch")]
        public async Task<IActionResult> GetBranch(string id)
        {
            var value = await _branchService.GetByIdAsync(id);
            return Ok(value);
        }
    }
}
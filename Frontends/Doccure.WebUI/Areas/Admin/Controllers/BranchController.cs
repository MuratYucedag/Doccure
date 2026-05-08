using Doccure.WebUI.Dtos.BranchDtos;
using Doccure.WebUI.Services.BranchServices;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }
        public async Task<IActionResult> BranchList()
        {
            var values = await _branchService.GetAllBranchesAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBranch()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch(CreateBranchDto createBranchDto)
        {
            await _branchService.CreateBranchAsync(createBranchDto);
            return RedirectToAction("BranchList");
        }

        public async Task<IActionResult> DeleteBranch(string id)
        {
            await _branchService.DeleteBranchAsync(id);
            return RedirectToAction("BranchList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBranch(string id)
        {
            var value = await _branchService.GetBranchByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBranch(UpdateBranchDto updateBranchDto)
        {
            await _branchService.UpdateBranchAsync(updateBranchDto);
            return RedirectToAction("BranchList");
        }
    }
}


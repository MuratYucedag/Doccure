using Doccure.IdentityService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(new
            {
                user.Id,
                user.Name,
                user.Surname,
                user.Email,
                user.PhoneNumber,
                user.Gender,
                user.BirthDate,
                user.BloodGroup,
                user.ImageUrl,
                user.City,
                user.Address
            });
        }
    }
}

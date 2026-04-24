using Doccure.IdentityService.Dtos;
using Doccure.IdentityService.Entities;
using Microsoft.AspNetCore.Identity;

namespace Doccure.IdentityService.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> LoginAsync(LoginDto dto)
        {

            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
                return false;

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

            return result.Succeeded;
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            var user = new AppUser()
            {
                UserName = dto.Username,
                Name = dto.Name,
                Surname = dto.Surname,
                City = dto.City,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            return result.Succeeded;
        }
    }
}

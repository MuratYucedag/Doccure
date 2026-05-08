using Doccure.IdentityService.Dtos;
using Doccure.IdentityService.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Doccure.IdentityService.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {

            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
                return null;

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

            if (!result.Succeeded)
                return null;

            return await GenerateToken(user);
        }

        private async Task<string> GenerateToken(AppUser user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim("name", user.Name ?? ""),
                new Claim("surname", user.Surname ?? "")
            };

            // 🔥 ROLE CLAIM EKLE
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpireMinutes"]!)),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
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

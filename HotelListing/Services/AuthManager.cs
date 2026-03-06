using HotelListing.Data;
using HotelListing.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelListing.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private ApiUser? _user;

        public AuthManager(UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<bool> ValidateUserAsync(LoginUserDTO userDTO)
        {
            _user = await _userManager.FindByEmailAsync(userDTO.Email);
            return (_user != null && await _userManager.CheckPasswordAsync(_user, userDTO.Password));
        }

        public async Task<string> CreateTokenAsync()
        {
            SigningCredentials signingCredentials = GetSigningCredentials();
            List<Claim> claims = await GetClaimsAsync();
            JwtSecurityToken token = GenerateToken(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateToken(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var issuer = _configuration.GetSection("JwtSettings:Issuer").Value;
            var lifetime =DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration.GetSection("JwtSettings:Lifetime").Value));

            return new JwtSecurityToken(issuer: issuer, claims: claims, signingCredentials: signingCredentials, expires: lifetime);
        }

        private async Task<List<Claim>> GetClaimsAsync()
        {
            var claims = new List<Claim>
            {
                new Claim (ClaimTypes.Name, _user.Email)
            };
            
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = _configuration.GetSection("JwtSettings:ApiKey").Value;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

    }
}

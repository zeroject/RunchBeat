using Application.DTOs;
using Application.Helpers;
using Application.Interfaces;
using Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;
        public AuthenticationService(IUserService userService_, IOptions<AppSettings> appSettings_)
        {
            _userService = userService_;
            _appSettings = appSettings_.Value;
        }

        public string Login(UserLoginDTO _userLoginDTO)
        {
            User user = _userService.GetUserByEmail(_userLoginDTO.Email);
            if (BCrypt.Net.BCrypt.Verify(_userLoginDTO.Password + user.Salt, user.Password))
            {
                return GenerateToken(user);
            }
            throw new Exception("INVALID LOGIN");
        }
        
        private string GenerateToken(User user_)
        {
            var key = Encoding.UTF8.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("email", user_.Email) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}

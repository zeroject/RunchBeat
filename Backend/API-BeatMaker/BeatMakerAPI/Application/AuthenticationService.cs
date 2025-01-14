﻿using Application.DTOs;
using Application.Helpers;
using Application.Interfaces;
using Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
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
        /// <summary>
        /// Checks if the user email/username and password is correct,
        /// if correct will call method generatetoken that generates a token.
        /// if not the method will throw a new exception of invalid login.
        /// </summary>
        /// <param name="userLoginDTO_"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string Login(UserLoginDTO userLoginDTO_)
        {
            User user = _userService.GetUserByEmailOrUsername(userLoginDTO_.Username_Email);
            if (BCrypt.Net.BCrypt.Verify(userLoginDTO_.Password + user.Salt, user.Password))
            {
                return GenerateToken(user);
            }
            throw new Exception("INVALID LOGIN");
        }
        /// <summary>
        /// Generates a token to be used for verfying a user.
        /// </summary>
        /// <param name="user_"></param>
        /// <returns></returns>
        private string GenerateToken(User user_)
        {
            var key = Encoding.UTF8.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("username_Email", user_.Username) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}

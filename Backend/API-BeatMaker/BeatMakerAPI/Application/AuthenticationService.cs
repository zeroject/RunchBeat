using Application.DTOs;
using Application.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;

        public AuthenticationService(IUserService userService_)
        {
            _userService = userService_;
        }

        public string login(UserLoginDTO _userLoginDTO)
        {
            throw new NotImplementedException();
        }

        public string Register(UserDTO userDTO_)
        {
            _userService.CreateNewUser(userDTO_);
        }


    }
}

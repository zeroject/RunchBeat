using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        public string login(UserLoginDTO userLoginDTO_);
        public string Register(UserDTO userDTO_);
    }
}

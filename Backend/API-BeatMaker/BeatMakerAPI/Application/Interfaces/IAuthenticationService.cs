using Application.DTOs;
using Domain;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        public string Login(UserLoginDTO userLoginDTO_);
    }
}

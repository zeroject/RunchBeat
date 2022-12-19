using Application.DTOs;
using Domain;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Login Method that takes UserLoginDTO as a parem.
        /// </summary>
        /// <param name="userLoginDTO_"></param>
        /// <returns></returns>
        public string Login(UserLoginDTO userLoginDTO_);
    }
}

using Application.DTOs;
using Domain;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public User GetUserByEmailOrUsername(string emailUsername_);
        public User CreateNewUser(UserDTO userDTO_);
        public User UpdateUserPassword(UserDTO userDTO_);
        public void DeleteUser(string email_);
    }
}

using Application.DTOs;
using Domain;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public User CreateNewUser(UserDTO userDTO_);
        public User UpdateUser(UserDTO userDTO_);
        public void DeleteUser(string email_);
        public User GetUserByEmailOrUsername(string emailUsername_);
        public User UpdateUserPassword(UserDTO userDTO_);
    }
}

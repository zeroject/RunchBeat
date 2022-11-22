

using Domain;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public User GetUser(string username_, string password_);
        public void CreateNewUser(User user_);
        public User UpdateUser(User user_);
        public void DeleteUser(int userId_);
    }
}

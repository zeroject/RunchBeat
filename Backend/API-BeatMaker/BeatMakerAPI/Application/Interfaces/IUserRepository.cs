using Domain;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        public User GetUser(string username_, string password_);
        public User CreateNewUser(User user_);
        public User UpdateUser(User user_);
        public void DeleteUser(string email_);
        public User GetUserByEmail(string email_);
    }
}

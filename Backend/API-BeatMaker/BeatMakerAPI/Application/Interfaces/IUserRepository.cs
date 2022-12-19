using Domain;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Gets a user by its email or username
        /// </summary>
        /// <param name="email_"></param>
        /// <returns></returns>
        public User GetUserByEmailOrUsername(string email_);
        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user_"></param>
        /// <returns></returns>
        public User CreateNewUser(User user_);
        /// <summary>
        /// Updates a user with new infomation
        /// </summary>
        /// <param name="user_"></param>
        /// <returns></returns>
        public User UpdateUser(User user_);
        /// <summary>
        /// Deltes the user.
        /// </summary>
        /// <param name="email_"></param>
        public void DeleteUser(string email_);
    }
}

using Application.DTOs;
using Domain;

namespace Application.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Gets a user by its email or username
        /// </summary>
        /// <param name="email_"></param>
        /// <returns></returns>
        public User GetUserByEmailOrUsername(string emailUsername_);
        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user_"></param>
        /// <returns></returns>
        public User CreateNewUser(UserDTO userDTO_);
        /// <summary>
        /// Updates a user with new infomation.
        /// </summary>
        /// <param name="user_"></param>
        /// <returns></returns>
        public User UpdateUser(UserDTO userDTO_);
        /// <summary>
        /// Updates the users password.
        /// </summary>
        /// <param name="userDTO_"></param>
        /// <returns></returns>
        public User UpdateUserPassword(UserDTO userDTO_);
        /// <summary>
        /// Deltes the user.
        /// </summary>
        /// <param name="email_"></param>
        public void DeleteUser(string email_);
    }
}

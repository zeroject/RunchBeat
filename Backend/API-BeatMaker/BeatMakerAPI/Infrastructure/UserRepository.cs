using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private DbContextOptions<DbContext> _options;
        public UserRepository()
        {
            _options = new DbContextOptionsBuilder<DbContext>().UseSqlite("Data Source = db.db").Options;
        }
        /// <summary>
        /// Gets the user if the email or username matches in the database.
        /// </summary>
        /// <param name="emailUsername_"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public User GetUserByEmailOrUsername(string emailUsername_)
        {
            using (var context = new DbContext(_options, ServiceLifetime.Scoped))
            {
                User userFromEmail = context._userEntries.Where(x => x.Email == emailUsername_).ToList().FirstOrDefault();
                User userFromUsername;

                if (userFromEmail != null)
                {
                    return userFromEmail;
                }
                else
                {
                    userFromUsername = context._userEntries.Where(x => x.Username == emailUsername_).ToList().FirstOrDefault();
                }

                if (userFromUsername != null)
                {
                    return userFromUsername;
                }
                else
                {
                    throw new Exception("Could not find User");
                }

            }
        }
        /// <summary>
        /// Creates a new user, also checks if a user with name or email is allready is in use.
        /// </summary>
        /// <param name="user_"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public User CreateNewUser(User user_)
        {
            using (var context = new DbContext(_options, ServiceLifetime.Transient))
            {
                if (CheckIfUserExists(user_.Username))
                {
                    throw new ArgumentException("User Already exists");
                }
                else
                {
                    _ = context._userEntries.Add(user_) ?? throw new ArgumentException("Failed to create user");
                    context.SaveChanges();
                    return user_;
                }
            }
        }
        /// <summary>
        /// Updates the user with new infomation
        /// </summary>
        /// <param name="user_"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public User UpdateUser(User user_)
        {
            using (var context = new DbContext(_options, ServiceLifetime.Scoped))
            {

                User userToUpdate = context._userEntries.Where(x => x.Username == user_.Username).ToList().FirstOrDefault() ?? throw new KeyNotFoundException("Could not find User");
                _ = context._userEntries.Update(userToUpdate) ?? throw new KeyNotFoundException("Could not find User");
                context.SaveChanges();
                return user_;
            }
        }

        /// <summary>
        /// Delets the user form database.
        /// </summary>
        /// <param name="email_"></param>
        /// <exception cref="ArgumentException"></exception>
        public void DeleteUser(string username_)
        {
            using (var context = new DbContext(_options, ServiceLifetime.Scoped))
            {
                User userToDelete = context._userEntries.Where(x => x.Username == username_).ToList().FirstOrDefault() ?? throw new ArgumentException("Failed to delete user");
                context._userEntries.Remove(userToDelete);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// checks if the given email is in use by another account.
        /// </summary>
        /// <param name="email_"></param>
        /// <returns></returns>
        private bool CheckIfUserExists(string username_)
        
        {
            using (var context = new DbContext(_options, ServiceLifetime.Transient))
            {
                User user = context._userEntries.Where(x => x.Username == username_).ToList().FirstOrDefault();
                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}

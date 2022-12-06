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

        public User CreateNewUser(User user_)
        {
            using (var context = new DbContext(_options, ServiceLifetime.Transient))
            {
                if (CheckIfUserExists(user_.Email))
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

        public User UpdateUser(User user_)
        {
            using (var context = new DbContext(_options, ServiceLifetime.Scoped))
            {
                User userToUpdate = context._userEntries.Where(x => x.Email == user_.Email).ToList().FirstOrDefault() ?? throw new KeyNotFoundException("Could not find User");
                context._userEntries.Update(userToUpdate);
                context.SaveChanges();
                return user_;
            }
        }

        public void DeleteUser(string email_)
        {
            using (var context = new DbContext(_options, ServiceLifetime.Scoped))
            {
                User userToDelete = context._userEntries.Where(x => x.Email == email_).ToList().FirstOrDefault() ?? throw new ArgumentException("Failed to delete user");
                context._userEntries.Remove(userToDelete);
                context.SaveChanges();
            }
        }

        private bool CheckIfUserExists(string email_)
        {
            using (var context = new DbContext(_options, ServiceLifetime.Transient))
            {
                User user = context._userEntries.Where(x => x.Email == email_).ToList().FirstOrDefault();
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

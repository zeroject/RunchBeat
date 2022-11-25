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
                    context._userEntries.Add(user_);
                    context.SaveChanges();
                    return user_;
                }
            }
        }

        public void DeleteUser(string email_)
        {
            using (var context = new DbContext(_options, ServiceLifetime.Scoped))
            {
                User userToDelete = context._userEntries.Where(x => x.Email == email_).ToList().FirstOrDefault();
                context._userEntries.Remove(userToDelete);
                context.SaveChanges();
            }
        }

        public User GetUser(string username_, string password_)
        {
            using (var context = new DbContext(_options, ServiceLifetime.Scoped))
            {
                return (context._userEntries.Where(x => x.Username == username_).ToList().FirstOrDefault() ?? throw new KeyNotFoundException("Could not find User"));
            }
        }

        public User UpdateUser(User user_)
        {
            using (var context = new DbContext(_options, ServiceLifetime.Scoped))
            {
                context._userEntries.Update(user_);
                context.SaveChanges();
                return user_;
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

        public User GetUserByEmail(string email_)
        {
            using (var context = new DbContext(_options, ServiceLifetime.Scoped))
            {
                return (context._userEntries.Where(x => x.Email == email_).ToList().FirstOrDefault() ?? throw new KeyNotFoundException("Could not find User"));
            }
        }
    }
}

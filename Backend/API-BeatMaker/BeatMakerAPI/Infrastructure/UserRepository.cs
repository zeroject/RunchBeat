using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private DbContextOptions<DbContext> _dbContextOptions;
        public UserRepository()
        {
            _dbContextOptions = new DbContextOptions<DbContext>();
        }

        public User CreateNewUser(User user_)
        {
            using (var context = new DbContext(_dbContextOptions, ServiceLifetime.Scoped))
            {
                if (CheckIfUserExists(user_.Email))
                {
                    throw new ArgumentException("User Allready exists");
                }
                else
                {
                    context._userEntries.Add(user_);
                    context.SaveChanges();
                    return user_;
                }
            }
        }

        public void DeleteUser(int userId_)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username_, string password_)
        {
            using (var context = new DbContext(_dbContextOptions, ServiceLifetime.Scoped))
            {
                return context._userEntries.Find(username_) ?? throw new KeyNotFoundException("Could not find User");
            }
        }

        public User UpdateUser(User user_)
        {
            using (var context = new DbContext(_dbContextOptions, ServiceLifetime.Scoped))
            {
                if (CheckIfUserExists(user_.Email))
                {
                    throw new ArgumentException("That Email is already is in use");
                } else if (CheckIfUserExists(user_.Username))
                {
                    throw new ArgumentException("That Username is already is in use");
                }
                context._userEntries.Update(user_);
                context.SaveChanges();
                return user_;
            }
        }

        private bool CheckIfUserExists(string eMail)
        {
            using (var context = new DbContext(_dbContextOptions, ServiceLifetime.Scoped))
            {
                User user = context._userEntries.Find(eMail) ?? throw new KeyNotFoundException("Could not find User");
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

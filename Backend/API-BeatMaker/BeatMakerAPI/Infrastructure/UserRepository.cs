﻿using Application.Interfaces;
using Domain;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {
        public void CreateNewUser(User user_)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userId_)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username_, string password_)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User user_)
        {
            throw new NotImplementedException();
        }
    }
}
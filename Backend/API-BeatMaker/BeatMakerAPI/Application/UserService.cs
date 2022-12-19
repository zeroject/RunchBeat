using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

namespace Application
{
    public class UserService : IUserService
    {

        private IUserRepository _userRepo;
        private IMapper _mapper;
        private IValidator<UserDTO> _validator;

        public UserService(IUserRepository repo_, IMapper mapper_, IValidator<UserDTO> validator_)
        {
            _mapper = mapper_;
            _userRepo = repo_;
            _validator = validator_;
        }
        /// <summary>
        /// Gets the user from a email or username.
        /// </summary>
        /// <param name="emailUsername_"></param>
        /// <returns></returns>
        public User GetUserByEmailOrUsername(string emailUsername_)
        {
            return _userRepo.GetUserByEmailOrUsername(emailUsername_);
        }
        /// <summary>
        /// creates a new user.
        /// </summary>
        /// <param name="userDTO_"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        public User CreateNewUser(UserDTO userDTO_)
        {
            var validation = _validator.Validate(userDTO_);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.ToString());
            }
            var salt = RandomNumberGenerator.GetBytes(32).ToString();
            User user = new User()
            {
                Email = HashString(userDTO_.Email, salt),
                Username = userDTO_.Username,
                Password = HashString(userDTO_.Password, salt),
                Salt = salt,
                Id = 0
            };
            return _userRepo.CreateNewUser(user);
        }
        /// <summary>
        /// updates the users password by encrypting it.
        /// </summary>
        /// <param name="userDTO_"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        public User UpdateUserPassword(UserDTO userDTO_)
        {
            var validation = _validator.Validate(userDTO_);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.ToString());
            }
            
            var salt = RandomNumberGenerator.GetBytes(32).ToString();
            User user = GetUserByEmailOrUsername(userDTO_.Email);
            User updatedUser = _mapper.Map<User>(userDTO_);
            updatedUser.Id = user.Id;
            updatedUser.Password = HashString(userDTO_.Password, salt);
            updatedUser.Salt = salt;
            return _userRepo.UpdateUser(updatedUser);
        }
        /// <summary>
        /// deletes a user
        /// </summary>
        /// <param name="email_"></param>
        public void DeleteUser(string username_)
        {
            _userRepo.DeleteUser(username_);
        }
        /// <summary>
        /// Hashes a string and adding salt.
        /// </summary>
        /// <param name="hashableString_"></param>
        /// <param name="salt_"></param>
        /// <returns></returns>
        private string HashString(string hashableString_, string salt_)
        {
            return BCrypt.Net.BCrypt.HashPassword(hashableString_ + salt_);
        }
    }
}
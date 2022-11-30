using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
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

        public User GetUserByEmailOrUsername(string emailUsername_)
        {
            return _userRepo.GetUserByEmailOrUsername(emailUsername_);
        }

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
                Email = userDTO_.Email,
                Username = userDTO_.Username,
                Password = HashString(userDTO_.Password, salt),
                Salt = salt,
                Is2FA = false,
                Id = 0
            };
            return _userRepo.CreateNewUser(user);
        }

        public User UpdateUser(UserDTO userDTO_)
        {
            var validation = _validator.Validate(userDTO_);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.ToString());
            }
            return _userRepo.UpdateUser(_mapper.Map<User>(userDTO_));
        }

        public User UpdateUserPassword(UserDTO userDTO_)
        {
            var validation = _validator.Validate(userDTO_);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.ToString());
            }

            var salt = RandomNumberGenerator.GetBytes(32).ToString();
            User updatedUser = _mapper.Map<User>(userDTO_);
            updatedUser.Password = HashString(userDTO_.Password, salt);
            updatedUser.Salt = salt;
            return _userRepo.UpdateUser(updatedUser);
        }

        public void DeleteUser(string email_)
        {
            _userRepo.DeleteUser(email_);
        }

        private string HashString(string hashableString_, string salt_)
        {
            return BCrypt.Net.BCrypt.HashPassword(hashableString_ + salt_);
        }
    }
}
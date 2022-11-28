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

        public UserService(IUserRepository repo, IMapper mapper, IValidator<UserDTO> validator)
        {
            _mapper = mapper;
            _userRepo = repo;
            _validator = validator;
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
                Password = BCrypt.Net.BCrypt.HashPassword(userDTO_.Password + salt),
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

        public void DeleteUser(string email_)
        {
            _userRepo.DeleteUser(email_);
        }

        public User GetUserByEmailOrUsername(string emailUsername_)
        {
            return _userRepo.GetUserByEmailOrUsername(emailUsername_);
        }
    }
}
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;

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

        public User GetUser(string username_, string password_)
        {
            return _userRepo.GetUser(username_, password_);
        }

        public User CreateNewUser(UserDTO userDTO_)
        {
            var validation = _validator.Validate(userDTO_);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.ToString());
            }
            return _userRepo.CreateNewUser(_mapper.Map<User>(userDTO_));
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
    }
}
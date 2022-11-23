using Application;
using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;
using Infrastructure;
using Moq;

namespace APITests
{
    public class UserTests
    {
        public static List<User> GetData()
        {
            var allData = new List<User>
            {
                new User(){Id = 1, Username="Casper", Password="gal12345", Email="adof@gg.org", Is2FA=true },
                new User(){Id = 1, Username="Anders", Password="numseerstor123", Email="adoddd@gg.org", Is2FA=false },
                new User(){Id = 1, Username="Kasper", Password="gal123456", Email="heløjsovs@gg.org", Is2FA=true }
            };
            return allData;
        }

        private UserService userService;
        private Mock<IUserRepository> userRepo = new Mock<IUserRepository>();
        public UserTests()
        {
            IValidator<UserDTO> validator = new UserValidator();
            var mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<UserDTO, User>();
            }).CreateMapper();
            userService = new UserService(userRepo.Object, mapper, validator);
        }
        
        [Fact]
        public void TestIfUserIsValid()
        {
            // Arange
            UserDTO userDTO = new UserDTO()
            {
                Email = "test",
                Username = "test",
                Password = "test",
                Is2FA = true
            };
            // Arange & Act & Assert
            try
            {
                userService.CreateNewUser(userDTO); 
            } catch(Exception e) 
            {
                Assert.Equal(typeof(ValidationException), e.GetType());
            };
        }
        [Theory]
        [MemberData(nameof(GetData))]
        public void TestIfUserWasCreated()
        {
            // Arange
            userRepo.Setup(x=>x.GetUser(user.Username, user.Password)).Returns(user);

            // Act
            User userTest = userService.GetUser("casp", "password123456");
            // Assert
            Assert.Equal(user.Email, userTest.Email);
        }
        [Fact]
        public void TestIfUserWasDeletedFromDatabase()
        {
            // Arange
            IValidator<UserDTO> validator = new UserValidator();
            var mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<UserDTO, User>();
            }).CreateMapper();
            IUserRepository userRepository = new UserRepository();
            IUserService userRepo;
            userRepo = new UserService(userRepository, mapper, validator);
            // Act
            try
            {
                userRepo.DeleteUser("me");
                User comebackUser = userRepo.GetUser("DaBeaa", "gal123");
            } catch(Exception e)
            {
                Assert.Equal(typeof(Exception), e.GetType());
            }
        }
    }
}
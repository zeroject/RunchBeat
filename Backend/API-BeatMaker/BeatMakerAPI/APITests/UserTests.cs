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
            { Email = "test", Username = "test", Password = "test", Is2FA = true };
            // Act & Assert
            try
            {
                userService.CreateNewUser(userDTO); 
            } catch(Exception e) 
            {
                Assert.Equal(typeof(ValidationException), e.GetType());
            };
        }
        [Theory]
        [InlineData(1, "Casper", "gal12345", "adof@gg.org", true)]
        [InlineData(2, "Anders", "MegetSikkertKodeord", "anders@zomf.org", false)]
        [InlineData(3, "Magus", "jegelskerbannaner1234", "casp@zomr.org", true)]
        public void TestIfUserWasCreated(int userId_, string username_, string password_, string email_, bool is2FA_)
        {
            // Arrange
            User user = new User() { Id = userId_, Username = username_, Password = password_, Email = email_, Is2FA = is2FA_};
            userRepo.Setup(x => x.GetUserByEmailOrUsername(username_)).Returns(user);

            // Act
            User userTest = userService.GetUserByEmailOrUsername(username_);

            // Assert
            Assert.Equal(email_, userTest.Email);
        }
    }
}
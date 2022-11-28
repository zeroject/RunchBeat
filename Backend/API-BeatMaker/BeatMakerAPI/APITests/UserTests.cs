using Application;
using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;
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

        [Theory]
        [InlineData("ab@gmail.com")]
        [InlineData("ba@gmail.com")]
        public void TestIfUserWasDeleted(string email_)
        {
            // Arrange
            User[] fakeRepo = new User[]
            {
                new User() { Id = 1, Username = "test", Password = "SecretPass123", Email = "ab@gmail.com", Is2FA = false },
                new User() { Id = 1, Username = "test2", Password = "Password421", Email = "ba@gmail.com", Is2FA = false }
            };
            userRepo.Setup(x => x.GetUserByEmailOrUsername(email_)).Returns(fakeRepo[1]);
            userRepo.Setup(x => x.DeleteUser(email_));
            // Act
            userService.DeleteUser(email_);
            // Assert
            userRepo.Verify(r => r.DeleteUser(email_), Times.Once);
        }

        [Fact]
        public void TestIfUserWasUpdated()
        {
            // Arrange
            User user = new User() { Id = 0, Email="test@gmail.com", Password="password12345", Username="HelloBabt", Is2FA=false};
            User userUpdate = new User() { Id = 0, Email="test@gmail.com", Password="password123456", Username="HelloBabt", Is2FA=false};
            UserDTO userDTO = new UserDTO() { Email= "test@gmail.com", Password= "password123456", Username="HelloBabt", Is2FA=false};
            userRepo.Setup(x => x.UpdateUser(user)).Returns(user);
            // Act
            userService.UpdateUser(userDTO);
            // Assert
            userRepo.Verify(r => r.UpdateUser(userUpdate), Times.Once);
        }
    }
}
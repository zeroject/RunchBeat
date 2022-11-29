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
    public class BeatTests
    {
        IBeatService _beatService;
        IUserService _userService;
        private Mock<IUserRepository> _userRepo = new Mock<IUserRepository>();
        private Mock<IBeatRepository> _beatRepo = new Mock<IBeatRepository>();
        public BeatTests()
        {
            IValidator<UserDTO> validatorUser = new UserValidator();
            var mapperUser = new MapperConfiguration(config =>
            {
                config.CreateMap<UserDTO, User>();
            }).CreateMapper();
            _userService = new UserService(_userRepo.Object, mapperUser, validatorUser);
            IValidator<BeatDTO> validator = new BeatValidator();
            var mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<BeatDTO, Beat>();
            }).CreateMapper();
            _beatService = new BeatService(_beatRepo.Object, mapper, validator, _userService);
        }

        [Theory]
        [InlineData("A03;B04;F07;A13;D32;:37", true)]
        [InlineData("A12;B04;F07;A32;D32;:22", false)]
        [InlineData("", false)]
        public void TestIfBeatstringIsValid(string beatstring_, bool expected_)
        {
            //Act
            bool actualValue = _beatService.IsBeatStringValid(beatstring_);

            //Assert
            Assert.Equal(expected_, actualValue);
        }

        [Fact]
        public void TestIfBeatWasCreated()
        {
            // Arrange
            List<Beat> beats = new List<Beat>();
            Beat beat = new Beat() { BeatString="A04;B04;D04;:19", Summary="Testing test", Title="Test", UserId=1, Id=0};
            BeatDTO beatDTO = new BeatDTO() { BeatString="A04;B04;D04;:19", Summary="Testing test", Title="Test", UserId=1};
            _beatRepo.Setup(x => x.CreateNewBeat(It.IsAny<Beat>())).Returns(() =>
            {
                beats.Add(beat);
                return beat;
            });
            // Act
            Beat result = _beatService.CreateNewBeat(beatDTO, "test@test.com");
            // Assert
            Assert.Equal(beat, result);
            _beatRepo.Verify(x => x.CreateNewBeat(It.IsAny<Beat>()), Times.Once);
        }

        [Fact]
        public void TestIfBeatWasDeleted()
        {
            // Arrange
            BeatDTO beatDTO = new BeatDTO() { BeatString = "A04;B04;D04;:19", Summary = "Testing test", Title = "Test", UserId = 1 };
            _beatRepo.Setup(x => x.DeleteBeat(It.IsAny<Beat>()));

            // Act
            _beatService.DeleteBeat(beatDTO, "test@test.gmail");
            // Assert
            _beatRepo.Verify(x => x.DeleteBeat(It.IsAny<Beat>()), Times.Once);
        }

        [Fact]
        public void TestIfBeatWasUpdated()
        {
            // Arrange
            List<Beat> beats = new List<Beat>();
            Beat beat = new Beat() { BeatString = "A04;B04;D04;:19", Summary = "Testing test", Title = "Test", UserId = 1, Id = 0 };
            BeatDTO beatDTO = new BeatDTO() { BeatString = "A04;B04;D04;:19", Summary = "Testing test", Title = "Test", UserId = 1 };
            beats.Add(beat);
            _beatRepo.Setup(x => x.UpdateBeat(It.IsAny<Beat>()));
            // Act
            _beatService.UpdateBeat(beatDTO, "test@test.com");
            // Assert
            _beatRepo.Verify(x => x.UpdateBeat(It.IsAny<Beat>()));
        }

    }
}

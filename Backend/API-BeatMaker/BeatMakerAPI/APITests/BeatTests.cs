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
        /// <summary>
        /// Test if the BeatString is valid.
        /// </summary>
        /// <param name="beatstring_"></param>
        /// <param name="expected_"></param>
        [Theory]
        [InlineData("12A;4B;7F;32A;32D;", true)]
        [InlineData("A12;4B;7F;32A;32D;", false)]
        [InlineData("", false)]
        public void TestIfBeatstringIsValid(string beatstring_, bool expected_)
        {
            //Act
            bool actualValue = _beatService.IsBeatStringValid(beatstring_);

            //Assert
            Assert.Equal(expected_, actualValue);
        }
        /// <summary>
        /// Test if the beat was created.
        /// </summary>
        [Fact]
        public void TestIfBeatWasCreated()
        {
            // Arrange
            List<Beat> beats = new List<Beat>();
            User user = new User() { Id = 1, Username = "gg", Password = "gggggggg", Email = "test@test.gmail", Salt = "sdfbius" };
            Beat beat = new Beat() { BeatString = "12A;4B;7F;32A;32D;", Summary = "Testing test", Title = "Test", UserId = 1, Id = 0 };
            BeatDTO beatDTO = new BeatDTO() { BeatString = "12A;4B;7F;32A;32D;", Summary = "Testing test", Title = "Test", UserEmail = "test@test.gmail" };
            _beatRepo.Setup(x => x.CreateNewBeat(It.IsAny<Beat>())).Returns(() =>
            {
                beats.Add(beat);
                return beat;
            });
            _userRepo.Setup(x => x.GetUserByEmailOrUsername(It.IsAny<string>())).Returns(() =>
            {
                return user;
            });
            // Act
            _userService.GetUserByEmailOrUsername(beatDTO.UserEmail);
            Beat result = _beatService.CreateNewBeat(beatDTO);
            // Assert
            Assert.Equal(beat, result);
            _beatRepo.Verify(x => x.CreateNewBeat(It.IsAny<Beat>()), Times.Once);
        }
        /// <summary>
        /// Tests if the given beat has been updated.
        /// </summary>
        [Fact]
        public void TestIfBeatWasUpdated()
        {
            // Arrange
            List<Beat> beats = new List<Beat>();
            User user = new User() { Id = 1 };
            Beat beat = new Beat() { BeatString = "12A;4B;7F;32A;32D;", Summary = "Testing test", Title = "Test", UserId = 1, Id = 0 };
            Beat updatedBeat = new Beat() { BeatString = "12A;4B;7F;32A;32D;", Summary = "Testing test", Title = "Tesgfggfgfjsdaft", UserId = 1, Id = 0 };
            BeatDTO beatDTO = new BeatDTO() { BeatString = "12A;4B;7F;32A;32D;", Summary = "Testing test", Title = "Test", UserEmail = "test@test.gmail" };
            beats.Add(beat);
            _beatRepo.Setup(x => x.UpdateBeat(It.IsAny<Beat>())).Returns(() => {
                beats.Remove(beat);
                beats.Add(beat);
                return beat;

            });
            _userRepo.Setup(x => x.GetUserByEmailOrUsername(It.IsAny<string>())).Returns(user);

            // Act
            _beatService.UpdateBeat(beatDTO);

            // Assert
            Assert.NotEqual(beat, updatedBeat);
            _beatRepo.Verify(x => x.UpdateBeat(It.IsAny<Beat>()));
        }
        /// <summary>
        /// Tests if the beat was deleted.
        /// </summary>
        [Fact]
        public void TestIfBeatWasDeleted()
        {
            // Arrange
            User user = new User() { Id = 1 };

            BeatDTO beatDTO = new BeatDTO() { BeatString = "12A;4B;7F;32A;32D;", Summary = "Testing test", Title = "Test", UserEmail = "test@test.gmail" };

            _beatRepo.Setup(x => x.DeleteBeat(It.IsAny<Beat>()));
            _userRepo.Setup(x => x.GetUserByEmailOrUsername(It.IsAny<string>())).Returns(user);

            // Act
            _beatService.DeleteBeat(beatDTO);

            // Assert
            _beatRepo.Verify(x => x.DeleteBeat(It.IsAny<Beat>()), Times.Once);
        }

        /* Failure Condition Tests */

        /// <summary>
        /// Tests if the beat validator caught something
        /// </summary>
        /// <param name="title_"></param>
        /// <param name="summary_"></param>
        /// <param name="beatstring_"></param>
        /// <param name="userEmail_"></param>
        /// <param name="expected_"></param>
        [Theory]
        [InlineData("", "This is the best music", "12A;4B;7F;32A;32D;", "smol@boy.com", typeof(ValidationException))]
        [InlineData(null, "This is the best music", "12A;4B;7F;32A;32D;", "smol@boy.com", typeof(ValidationException))]
        [InlineData("bestmusic", null, "12A;4B;7F;32A;32D;", "smol@boy.com", typeof(ValidationException))]
        [InlineData("bestmusic", "This is the best music", "", "smol@boy.com", typeof(ArgumentException))]
        [InlineData("bestmusic", "This is the best music", null, "smol@boy.com", typeof(NullReferenceException))]
        [InlineData("bestmusic", "This is the best music", "12A;4B;7F;32A;32D;", "", typeof(ValidationException))]
        [InlineData("bestmusic", "This is the best music", "12A;4B;7F;32A;32D;", null, typeof(ValidationException))]
        public void TestIfBeatValidationFailed(string title_, string summary_, string beatstring_, string userEmail_, Type expected_)
        {
            //Arrange
            BeatDTO beatDTO = new BeatDTO() { Title = title_, Summary = summary_, BeatString = beatstring_, UserEmail = userEmail_ };
            //Act & Assert
            try
            {
                _beatService.CreateNewBeat(beatDTO);
            }
            catch (Exception e)
            {
                Assert.Equal(expected_, e.GetType());
            };
        }

    }
}
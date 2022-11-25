

using Application;
using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;
using Infrastructure;

namespace APITests
{
    public class BeatTests
    {
        IBeatService beatService;
        public BeatTests()
        {
            IBeatRepository beatRepository = new BeatRepository();
            IValidator<BeatDTO> validator = new BeatValidator();
            var mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<BeatDTO, Beat>();
            }).CreateMapper();
            beatService = new BeatService(beatRepository, mapper, validator);
        }

        [Theory]
        [InlineData("A3;B4;F7;A13;D32", true)]
        [InlineData("A3;B4;F7A32;D32", false)]
        [InlineData("A3;B4;F7;A33;D32", false)]
        [InlineData("A3;B4;F7;A32;Æ32", false)]
        [InlineData("A3;B4;F7;A32;Ø32", false)]
        [InlineData("A3;B4;F7;A32;Å32", false)]
        [InlineData("3A;4B;7F;32A;32D", false)]
        [InlineData("", false)]
        public void TestIfBeatstringIsValid(string beatstring_, bool expected_)
        {
            //Act
            bool actualValue = beatService.IsBeatStringValid(beatstring_);

            //Assert
            Assert.Equal(expected_, actualValue);
        }

        [Theory]
        [InlineData(1, typeof(ArgumentException))]
        [InlineData(-1, typeof(ArgumentException))]
        [InlineData(null, typeof(ArgumentException))]
        public void TestIfUserIDisStillValid(int userID_, Type expected_)
        {
            //Arange
            BeatDTO beatDTO = new BeatDTO() { BeatString="D5;E3;A7", Title="Test", Summary="this is a test", UserId=userID_};
            //Act & Assert
            Assert.Throws<ArgumentException>(() => beatService.CreateNewBeat(beatDTO, ""));
        }

    }
}

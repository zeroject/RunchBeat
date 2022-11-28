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
        IBeatService _beatService;
        IUserService _userService;
        public BeatTests()
        {
            IBeatRepository beatRepository = new BeatRepository();
            IValidator<BeatDTO> validator = new BeatValidator();
            var mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<BeatDTO, Beat>();
            }).CreateMapper();
            _beatService = new BeatService(beatRepository, mapper, validator, _userService);
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

    }
}



using Application;
using Application.DTOs;
using Application.Interfaces;

namespace APITests
{
    public class BeatTests
    {
        public BeatTests()
        {

        }

        [Theory]
        [InlineData("A3;B4;F7;A13;D32", true)]
        [InlineData("A3;B4;F7A32;D32", false)]
        [InlineData("A3;B4;F7;A33;D32", false)]
        [InlineData("A3;B4;F7;A32;Æ32", false)]
        [InlineData("A3;B4;F7;A32;Ø32", false)]
        [InlineData("A3;B4;F7;A32;Å32", false)]
        [InlineData("", false)]
        public void TestIfBeatstringIsValid(string beatstring_, bool expected_)
        {
            //Arrange
            IBeatService beatService = new BeatService();

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
            IBeatService beatService = new BeatService();
            BeatDTO beatDTO = new BeatDTO() { BeatString="D5;E3;A7", Name="Test", Summary="this is a test", UserId=userID_};
            //Act & Assert
            Assert.Throws<ArgumentException>(() => beatService.CreateNewBeat(beatDTO));
        }

    }
}



using Application;
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

    }
}

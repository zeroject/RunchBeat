using Application;
using Application.Interfaces;
using Domain;
using Infrastructure;
using Moq;

namespace APITests
{
    public class UserTests
    {
        User testUser = new User(0, "DaBeaa", "gal123", "adof@gg.org", false);
        public static List<User> GetData()
        {
            var allData = new List<User>
            {
                new User(1, "hans", "peter123", "email@gg.org", true),
                new User(-1, "hans", "peter123", "email@gg.org", true),
                new User(1, null, "peter123", "email@gg.org", true),
                new User(1, "hans", null, "email@gg.org", true),
                new User(1, "hans", "peter123", null, true),
                new User(1, "hans", "peter123", "email@gg.org", false),
                new User(1, "", "peter123", "email@gg.org", true),
                new User(1, "hans", "", "email@gg.org", true),
                new User(1, "hans", "peter123", "", true)
            };
            return allData;
        }

        [Theory]
        [MemberData(nameof(GetData), typeof(ArgumentException))]
        public void TestIfUserIsValid(User user_, Type expected)
        {
            // Arange
            IUserService userService;
            userService = new UserService();
            // Act & Assert
            try
            {
                userService.CreateNewUser(user_); 
            } catch(ArgumentException e) 
            {
                Assert.Equal(expected, e.GetType());
            };
        }
        [Fact]
        public void TestIfUserWasCreated()
        {
            // Arange
            IUserService userService;
            userService = new UserService();
            // Act
            userService.CreateNewUser(testUser);
            User comebackUser = userService.GetUser("DaBeaa", "gal123");
            // Assert
            Assert.Equal(testUser.Email, comebackUser.Email);
        }
        [Fact]
        public void TestIfUserWasDeletedFromDatabase()
        {
            // Arange
            IUserService userService = new UserService();
            // Act
            try
            {
                userService.DeleteUser(testUser.Id);
                User comebackUser = userService.GetUser("DaBeaa", "gal123");
            } catch(Exception e)
            {
                Assert.Equal(typeof(Exception), e.GetType());
            }
        }
    }
}
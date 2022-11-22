using Application.Interfaces;
using Domain;
using Moq;

namespace APITests
{
    public class UserTests
    {
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

        private readonly Mock<IUserRepository<int>, I();

        [Theory]
        [MemberData(nameof(GetData))]
        public void TestIfUserIsValid(User user_)
        {

        }

        public void TestIfUserWasCreated()
        {

        }
    }
}
using Application;
using Application.Interfaces;
using Domain;
using Infrastructure;
using Moq;

namespace APITests
{
    public class UserTests
    {
        User testUser = new User() { Id=0, Username="DaBeaa", Password="gal123", Email="adof@gg.org", Is2FA=false };
        public static User[] GetData()
        {
            var allData = new User[]
            {
                new User(){ Id=0, Username="", Password="gal12345", Email="adof@gg.org", Is2FA=true },
                new User(){ Id=1, Username="DaBeaa", Password="", Email="adof@gg.org", Is2FA=false },
                new User(){ Id=2, Username="DaBeaa", Password="gal12345", Email="", Is2FA=true },
                new User(){ Id=3, Username=null, Password="gal12345", Email="adof@gg.org", Is2FA=false },
                new User(){ Id=4, Username="DaBeaa", Password=null, Email="adof@gg.org", Is2FA=false },
                new User(){ Id=5, Username="DaBeaa", Password="gal12345", Email=null, Is2FA=false },
                new User(){ Id=5, Username="DaBeaa", Password="gal123", Email="adof@gg.org", Is2FA=false },
                new User(){ Id=-1, Username="DaBeaa", Password="gal12323", Email="adof@gg.org", Is2FA=false },
            };
            return allData;
        }

        Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();

        
        [Fact]
        public void TestIfUserIsValid()
        {
            // Arange
            mockUserRepository.Setup(r => r.GetAll()).Returns(GetData);
            IUserService user = new UserService(mockUserRepository);
            IUserRepository userRepo;
            userRepo = new UserRepository();
            // Act & Assert
            try
            {
                userRepo.CreateNewUser(); 
            } catch(Exception e) 
            {
                Assert.Equal(typeof(ArgumentException), e.GetType());
            };
        }
        [Fact]
        public void TestIfUserWasCreated()
        {
            // Arange
            IUserRepository userRepo = new UserRepository();

            // Act
            userRepo.CreateNewUser(testUser);
            User comebackUser = userRepo.GetUser("DaBeaa", "gal123");
            // Assert
            Assert.Equal(testUser.Email, comebackUser.Email);
        }
        [Fact]
        public void TestIfUserWasDeletedFromDatabase()
        {
            // Arange
            IUserRepository userRepo;
            userRepo = new UserRepository();
            // Act
            try
            {
                userRepo.DeleteUser(testUser.Email);
                User comebackUser = userRepo.GetUser("DaBeaa", "gal123");
            } catch(Exception e)
            {
                Assert.Equal(typeof(Exception), e.GetType());
            }
        }
    }
}
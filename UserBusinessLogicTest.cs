using Moq;
using SD_340_W22SD_Final_Project_Group6.BLL;
using SD_340_W22SD_Final_Project_Group6.Models;

namespace SD_125_W22SD_UnitTest
{
    [TestClass]
    public class UserBusinessLogicTest
    {
        [TestMethod]
        public async Task ShouldReturnCorrectUserWhenMatchingIdPassed()
        {
            var user = new ApplicationUser
            {
                UserName = "User1",
                Id = "UserId1",
                Email = "user1@jello.com"
            };
            var userManager = FakeUserManager.GetFakeUserManager(new List<ApplicationUser> { user });
            var userBusinessLogic = new UserBusinessLogic(userManager);

            var result = await userBusinessLogic.FindById(user.Id);

            Assert.AreEqual(user.Id, result.Id);
        }

        [TestMethod]
        public async Task ShouldReturnNullWhenNoMatchingIdPassed()
        {
            var user = new ApplicationUser
            {
                UserName = "User1",
                Id = "UserId1",
                Email = "user1@jello.com"
            };
            var userManager = FakeUserManager.GetFakeUserManager(new List<ApplicationUser> { user });
            var userBusinessLogic = new UserBusinessLogic(userManager);

            var result = await userBusinessLogic.FindById("UserId2");

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task ShouldReturnCorrectUserWhenMatchingNamePassed()
        {
            var user = new ApplicationUser
            {
                UserName = "User1",
                NormalizedUserName = "USER1",
                Id = "UserId1",
                Email = "user1@jello.com"
            };
            var userManager = FakeUserManager.GetFakeUserManager(new List<ApplicationUser> { user });
            var userBusinessLogic = new UserBusinessLogic(userManager);

            var result = await userBusinessLogic.FindByName(user.UserName);

            Assert.AreEqual(user.Id, result.Id);
            Assert.AreEqual(user.UserName, result.UserName);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EskholFitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void UserControllerTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange

            var userName = Guid.NewGuid().ToString();

            //Act

            var controller = new UserController(userName);

            //Assert

            Assert.AreEqual(userName, controller.CurrentUser.userName);
        }

        [TestMethod()]
        public void GetUsersDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //arrange
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            var controller = new UserController(userName);
            var controller2 = new UserController(userName);

            //act
            controller.SetNewUserData(gender, birthDate, weight, height);

            //assert
            Assert.AreEqual(userName, controller2.CurrentUser.userName);
        }
    }
}
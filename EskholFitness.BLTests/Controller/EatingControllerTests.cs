using Microsoft.VisualStudio.TestTools.UnitTesting;
using EskholFitness.BL.Controller;
using System;
using EskholFitness.BL.Model;
using System.Linq;

namespace EskholFitness.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddFoodTest()
        {
            //Arrange
            Random rnd = new Random();
            UserController uc = new UserController(Guid.NewGuid().ToString());
            EatingController ec = new EatingController(uc.CurrentUser);
            Food food = new Food(Guid.NewGuid().ToString(), rnd.Next(500, 5000) / 10.0, rnd.Next(500, 5000) / 10.0, rnd.Next(500, 5000) / 10.0, rnd.Next(500, 5000) / 10.0);
            
            //act
            ec.AddFood(food, 100);

            //Assert
            Assert.AreEqual(food.Name, ec.Eating.Foods.First().Key.Name);
        }
    }
}
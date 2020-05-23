using Microsoft.VisualStudio.TestTools.UnitTesting;
using EskholFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EskholFitness.BL.Model;

namespace EskholFitness.BL.Controller.Tests
{
    [TestClass()]
    public class ExercizeControllerTests
    {
        [TestMethod()]
        public void ExercizeControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddExerciseTest()
        {
            //Arrange
            Random rnd = new Random();
            UserController uc = new UserController(Guid.NewGuid().ToString());
            ExercizeController ec = new ExercizeController(uc.CurrentUser);
            Activity act = new Activity(Guid.NewGuid().ToString(), rnd.Next(500, 5000) / 10.0);

            //act
            ec.AddExercise(act, DateTime.Today, DateTime.Now);

            //Assert
            Assert.AreEqual(act.ActivityName, ec.Activities.First().ActivityName);
        }
    }
}
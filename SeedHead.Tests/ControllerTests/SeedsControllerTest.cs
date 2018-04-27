using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SeedHead.Models;
using SeedHead.Controllers;
using System.Linq;
using SeedHead.Models.Repositories;
using Moq;

namespace SeedHead.Tests.ControllerTests
{

    [TestClass]
    public class SeedsControllerTests
    {
        Mock<ISeedRepository> mock = new Mock<ISeedRepository>();


        private void DbSetup()
        {
            mock.Setup(m => m.Seeds).Returns(new Seed[]
            {
                new Seed {},
                new Seed {},
                new Seed {}
            }.AsQueryable());
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult() // Confirms route returns view
        {
            //Arrange
            DbSetup();
            SeedsController controller = new SeedsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexContainsModelData_List() 
        {
            // Arrange
            DbSetup();
            ViewResult indexView = new SeedsController(mock.Object).Index() as ViewResult;

            // Act
            var result = indexView.ViewData.Model;

            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Seed>));
        }

        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            // Arrange
            Seed testSeed = new Seed();
            {
         
            };

            DbSetup();
            SeedsController controller = new SeedsController(mock.Object);

            // Act
            var resultView = controller.Details(testSeed.SeedId) as ViewResult;
            var model = resultView.ViewData.Model as Seed;

            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Seed));
        }

    }
        
}

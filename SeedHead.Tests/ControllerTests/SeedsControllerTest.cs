﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SeedHead.Models;
using SeedHead.Controllers;
using System.Linq;
using SeedHead.Data;
using SeedHead.Models.Repositories;
using Moq;

namespace SeedHead.Tests.ControllerTests
{

    [TestClass]
    public class SeedsControllerTests
    {
        Mock<ISeedRepository> mock = new Mock<ISeedRepository>();
        EFSeedRepository db = new EFSeedRepository(new TestDbContext());


        private void DbSetup()
        {
            mock.Setup(m => m.Seeds).Returns(new Seed[]
            {
                new Seed {SeedId = 1, Name = "Amaranth", Description = "a plant"},
                new Seed {SeedId = 2, Name = "Asparagus", Description = "another plant"},
                new Seed {SeedId = 3, Name = "Appleseeds", Description = "one more plant"}
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
         
            DbSetup();
            SeedsController controller = new SeedsController(mock.Object);

            // Act
            var resultView = controller.Details(testSeed.SeedId) as ViewResult;
            var model = resultView.ViewData.Model as Seed;

            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
        }

        [TestMethod]
        public void TestDB_Create_Adds()
        {
            SeedsController controller = new SeedsController(db);
            Seed newSeed = new Seed { SeedId = 100, Name = "Amaranth", Amount = 40, Description = "a plant", OfferId = 1};

            controller.Create(newSeed);
            var newList = (controller.Index() as ViewResult).ViewData.Model as List<Seed>;

            CollectionAssert.Contains(newList, newSeed);
            db.DeleteAll();
        }

    }
        
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        EFOfferRepository dbOffers = new EFOfferRepository(new TestDbContext());


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
        public void TestDB_CreateSeed_Adds()
        {
            //Arrange
            OffersController offerController = new OffersController(dbOffers);
            SeedsController controller = new SeedsController(db);

            Offer newOffer = new Offer { OfferId = 1, Name = "HFBW" };
            Seed newSeed = new Seed { SeedId = 100, Name = "Amaranth", Amount = 40, Description = "A plant", OfferId = 1 };

            //Act
            
            offerController.Create(newOffer);
            controller.Create(newSeed);
            var newList = (controller.Index() as ViewResult).ViewData.Model as List<Seed>;

            //Assert

            CollectionAssert.Contains(newList, newSeed);
            db.DeleteAll();
        }


        [TestMethod]
        public void TestDB_SeedEdit_Updates()
        {
            //Arrange
            OffersController offerController = new OffersController(dbOffers);
            SeedsController controller = new SeedsController(db);
            Offer newOffer = new Offer { OfferId = 10, Name = "HFBW" };
            Seed newSeed = new Seed { SeedId = 10, Name = "Amaranht", Amount = 40, Description = "A plant", OfferId = 10 };



            //Act
            offerController.Create(newOffer);
            controller.Create(newSeed);
            
            newSeed.Name = "Amaranth";
            controller.Edit(newSeed);
            var seedOutput = (controller.Details(10) as ViewResult).ViewData.Model as Seed;

            Assert.AreEqual(seedOutput.Name, "Amaranth");
            db.DeleteAll();
        }



    }
        
}

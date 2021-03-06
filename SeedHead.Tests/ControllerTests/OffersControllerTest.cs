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
    public class OffersControllerTests
    {
        Mock<IOfferRepository> mock = new Mock<IOfferRepository>();
        EFOfferRepository db = new EFOfferRepository(new TestDbContext());


        private void DbSetup()
        {
            mock.Setup(m => m.Offers).Returns(new Offer[]
            {
                new Offer {},
                new Offer {},
                new Offer {}
            }.AsQueryable());
        }

        [TestMethod]
        public void Mock_GetViewResultOfferIndex_ActionResult() // Confirms route returns view
        {
            //Arrange
            DbSetup();
            OffersController controller = new OffersController(mock.Object);

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
            ViewResult indexView = new OffersController(mock.Object).Index() as ViewResult;

            // Act
            var result = indexView.ViewData.Model;

            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Offer>));
        }

        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            // Arrange
            Offer testOffer = new Offer();
            {

            };

            DbSetup();
            OffersController controller = new OffersController(mock.Object);

            // Act
            var resultView = controller.Details(testOffer.OfferId) as ViewResult;
            var model = resultView.ViewData.Model as Offer;

            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Offer));
        }

        [TestMethod]
        public void TestDB_CreateOffer_Adds()
        {
            OffersController controller = new OffersController(db);
            Offer newOffer = new Offer { OfferId = 100, Name = "HFBW" };

            controller.Create(newOffer);
            var newList = (controller.Index() as ViewResult).ViewData.Model as List<Offer>;

            CollectionAssert.Contains(newList, newOffer);
            db.DeleteAll();
        }

        [TestMethod]
        public void TestDB_OfferEdit_Updates()
        {
            //Arrange
            OffersController controller = new OffersController(db);
            Offer newOffer = new Offer { OfferId = 1, Name = "HFBW" };
           


            //Act
            controller.Create(newOffer);
            newOffer.Name = "Human Flesh Body World";
            controller.Edit(newOffer);
            var offerOutput = (controller.Details(1) as ViewResult).ViewData.Model as Offer;

            Assert.AreEqual(offerOutput.Name, "Human Flesh Body World");
            db.DeleteAll();
        }



    }

}

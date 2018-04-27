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
    public class OffersControllerTests
    {
        Mock<IOfferRepository> mock = new Mock<IOfferRepository>();


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

    }

}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeedHead.Models;


namespace SeedHead.Tests
{
    [TestClass]
    public class OfferTests
    {
        [TestMethod]
        public void GetDescription_ReturnsOfferName_String()
        {
            //Arrange
            var offer = new Offer();

            offer.Name = "cool";

            //Act
            var result = offer.Name;

            //Assert
            Assert.AreEqual("cool", result);
        }
    }
}
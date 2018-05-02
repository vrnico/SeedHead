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

            offer.Name = "HFBW";

            //Act
            var result = offer.Name;

            //Assert
            Assert.AreEqual("HFBW", result);
        }
        [TestMethod]
        public void Offer_Equals_TrueIfSame()
        {
            //Arrange  Act
            Offer newOffer = new Offer("HFBW");
            Offer twoOffer = new Offer("HFBW");

            //Assert
            Assert.AreEqual(newOffer, twoOffer);

        }
    }
}
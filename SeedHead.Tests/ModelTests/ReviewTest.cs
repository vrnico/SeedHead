using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeedHead.Models;


namespace SeedHead.Tests
{
    [TestClass]
    public class ReviewTests
    {
        [TestMethod]
        public void Review_Equals_TrueIfSame()
        {
            //Arrange  Act
            Review newReview = new Review("Nico", 5, "Good plant");
            Review twoReview = new Review("Nico", 5, "Good plant");

            //Assert
            Assert.AreEqual(newReview, twoReview);

        }
    }
}
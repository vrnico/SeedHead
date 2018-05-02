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


        [TestMethod]
        public void Constructor_ReturnReview_ReviewConstructor()
        {
            //Arrange    Act
            Review newReview = new Review("Nico", 5, "Good plant");

            //Assert
            Assert.AreEqual(newReview.Name, "Nico");
        }

        [TestMethod]
        public void RatingOneThruFive_ReturnTrueIfRange_True()
        {
            //Arrange
            Review newReview = new Review("Nico", 5, "Good plant");
            Review twoReview = new Review("Nico", 10, "Good plant");

            //Act
            bool newResult = newReview.RatingOneThruFive();
            bool twoResult = twoReview.RatingOneThruFive();

            //Assert
            Assert.IsTrue(newResult);
            Assert.IsFalse(twoResult);
        }
    }
}
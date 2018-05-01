using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeedHead.Models;


namespace SeedHead.Tests
{
    [TestClass]
    public class SeedTests
    {
        [TestMethod]
        public void GetSeed_ReturnsSeedData_String()
        {
            //Arrange
            Seed seed = new Seed("Amaranth", 40, "A plant");
            //Act
            int id = seed.SeedId;
            string name = seed.Name;
            int amount = seed.Amount;
            string description = seed.Description;
            
            //Assert
            Assert.AreEqual(id, 0);
            Assert.AreEqual(name, "Amaranth");
            Assert.AreEqual(amount, 40);
            Assert.AreEqual(description, "A plant");
        }

        [TestMethod]
        public void Constructor_ReturnSeed_SeedConstructor()
        {
            //Arrange    Act
            Seed newSeed = new Seed("Amaranth", 40, "A plant");

            //Assert
            Assert.AreEqual(newSeed.Name, "Amaranth");
        }

        [TestMethod]
        public void Equals_TrueIfSame()
        {
            //Arrange  Act
            Seed newSeed = new Seed("Amaranth", 40, "A plant");
            Seed twoSeed = new Seed("Amaranth", 40, "A plant");

            //Assert
            Assert.AreEqual(newSeed, twoSeed);

        }

        [TestMethod]
        public void AverageRating_AverageRating()
        {
            //Arrange
            Seed newSeed = new Seed("Amaranth", 40, "A plant");
            Review newReview = new Review {ReviewId = 1, Name = "Nico", Rating = 5, Description = "Stoked" };
            Review twoReview = new Review { ReviewId = 2, Name = "Frank", Rating = 3, Description = "Bammer" };
            newSeed.Reviews = new List<Review> { newReview, twoReview };

            //Act
            int rating = newSeed.GetRating(newSeed);

            //Assert
            Assert.AreEqual(rating, 4);

        }

    }
}

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
        public void GetDescription_ReturnsSeedDescription_String()
        {
            //Arrange
            var seed = new Seed();

            seed.Description = "cool";

            //Act
            var result = seed.Description;

            //Assert
            Assert.AreEqual("cool", result);
        }
    }
}

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
    }
}

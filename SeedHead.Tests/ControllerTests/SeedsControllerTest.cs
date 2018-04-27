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
    public class SeedsControllerTests
    {
        Mock<ISeedRepository> mock = new Mock<ISeedRepository>();


        private void DbSetup()
        {
            mock.Setup(m => m.Seeds).Returns(new Seed[]
            {
                new Seed {Name = "Amaranth", Description = "fill", Amount = 40},
                new Seed {Name = "Arugula", Description = "fluff", Amount = 50},
                new Seed {Name = "Anice", Description = "stuff", Amount = 30}
            }.AsQueryable());
        }

    }
        
}

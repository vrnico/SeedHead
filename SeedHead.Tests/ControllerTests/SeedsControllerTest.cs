using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SeedHead.Models;
using SeedHead.Controllers;
using System.Linq;

namespace SeedHead.Tests.ControllerTests
{

    [TestClass]
    public class SeedsControllerTests
    {
        EFAnimalRepository db = new EFAnimalRepository(new TestDbContext());
        Mock<IAnimalRepository> mock = new Mock<IAnimalRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Animals).Returns(new Animal[]
            {
                new Animal {AnimalId = 1, Name = "Louis" },
                new Animal {AnimalId = 2, Name = "Coco" },
                new Animal {AnimalId = 3, Name = "Gordon" }
            }.AsQueryable());
        }


        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult() // Confirms route returns view
        {
            //Arrange
            DbSetup();
            AnimalsController controller = new AnimalsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexContainsModelData_List() // Confirms model as list of animals
        {
            // Arrange
            DbSetup();
            ViewResult indexView = new AnimalsController(mock.Object).Index() as ViewResult;

            // Act
            var result = indexView.ViewData.Model;

            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Animal>));
        }


        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            // Arrange
            Animal testAnimal = new Animal();
            {
                testAnimal.AnimalId = 1;
                testAnimal.Name = "Louis";
                testAnimal.Species = "Canine";
                testAnimal.Sex = "Male";
                testAnimal.HabitatType = "Domestic";
                testAnimal.VetId = 1;
            };

            DbSetup();
            AnimalsController controller = new AnimalsController(mock.Object);

            // Act
            var resultView = controller.Details(testAnimal.AnimalId) as ViewResult;
            var model = resultView.ViewData.Model as Animal;

            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Animal));
        }
    }
}

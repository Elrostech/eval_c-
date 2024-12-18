using Geometrie.API.Controllers;
using Geometrie.BLL;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Geometrie.API.Tests
{
    public class CercleControllerTests
    {
        [Fact]
        public void GetAll_ReturnsEmptyListInitially()
        {
            var controller = new CercleController();

            var result = controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var list = Assert.IsType<List<Cercle>>(okResult.Value);
            Assert.Empty(list);
        }

        [Fact]
        public void Add_AddsCercleSuccessfully()
        {
            var controller = new CercleController();
            var cercle = new Cercle(new Point(0, 0), 5);

            var result = controller.Add(cercle);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(cercle, createdResult.Value);
        }

        [Fact]
        public void GetTotalArea_CalculatesCorrectly()
        {
            var controller = new CercleController();
            var cercle1 = new Cercle(new Point(0, 0), 3); 
            var cercle2 = new Cercle(new Point(1, 1), 4); 

            controller.Add(cercle1);
            controller.Add(cercle2);

            var ids = new List<int> { 0, 1 };
            var result = controller.GetTotalArea(ids);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var totalArea = Assert.IsType<double>(okResult.Value);
            Assert.Equal(78.54, totalArea, 2);
        }
    }
}

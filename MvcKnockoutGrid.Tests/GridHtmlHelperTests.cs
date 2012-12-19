using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MvcKnockoutGrid.Tests
{
    public class GridHtmlHelperTests
    {
        [Fact]
        public void GridWithId_Returns_GridInstanceWithValidIdAndData()
        {
            // Arrange
            var testData = new[]
                {
                    new { Name = "Name 1", Id = 1},
                    new { Name = "Name 2", Id = 2}
                };

            // Act
            var grid = GridHtmlHelper.Grid(null, "TestGrid", testData);

            // Assert
            Assert.Equal("TestGrid", grid.Id);
        }
    }
}
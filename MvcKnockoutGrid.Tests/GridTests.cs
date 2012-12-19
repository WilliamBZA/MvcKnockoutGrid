using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MvcKnockoutGrid.Tests
{
    public class GridTests
    {
        [Fact]
        public void Passing_Id_And_Data_Creates_Grid_With_Matching_Id()
        {
            // Arrange
            var testData = new[]
                {
                    new { Name = "Name 1", Id = 1},
                    new { Name = "Name 2", Id = 2}
                };

            // Act
            var grid = GridFactory.CreateGrid("TestId", testData);

            // Assert
            Assert.Equal("TestId", grid.Id);
        }

        [Fact]
        public void Passing_null_For_Id_Throws_ArgumentNullException()
        {
            // Arrange
            bool argumentExceptionThrown = false;
            var testData = new[]
                {
                    new { Name = "Name 1", Id = 1},
                    new { Name = "Name 2", Id = 2}
                };

            // Act
            try
            {
                var grid = GridFactory.CreateGrid<object>(null, testData);
            }
            catch (ArgumentNullException)
            {
                argumentExceptionThrown = true;
            }

            Assert.True(argumentExceptionThrown);
        }

        [Fact]
        public void Passing_null_For_Data_Throws_ArgumentNullException()
        {
            // Arrange
            bool argumentExceptionThrown = false;

            // Act
            try
            {
                var grid = GridFactory.CreateGrid<object>("TestId", null);
            }
            catch (ArgumentNullException)
            {
                argumentExceptionThrown = true;
            }

            Assert.True(argumentExceptionThrown);
        }

        [Fact]
        public void Grid_With_Valid_Id_Renders_Correctly()
        {
            // Arrange
            var testData = new[]
                {
                    new { Name = "Name 1", Id = 1},
                    new { Name = "Name 2", Id = 2}
                };

            var grid = GridFactory.CreateGrid<object>("TestId", testData);

            // Act
            var markup = grid.ToHtmlString();

            // Assert
            Assert.True(markup.Contains(@"<table>
    <thead>
        <tr>
            <th>Name</th><th>Id</th>
        </tr>
    </thead>
    <tbody data-bind=""foreach: seats"">
        <tr>
            <td data-bind=""text: Name""></td><td data-bind=""text: Id""></td>
        </tr>    
    </tbody>
</table>"));
        }
    }
}
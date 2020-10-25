using DBC.Domain.ShapeCategorizers;
using DBC.Model;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace DBC.DomainTests
{
    public class RectangleCategorizerTests
    {
        [Theory]
        [InlineData(20,10)]
        [InlineData(11,10)]
        [InlineData(10.5,10.4)]
        public void FlatRectangles(double width, double height)
        {
            // Arrange
            var categurizer = new RectangleCategorizer();
            var rectangle = new Rectangle(width, height);

            // Act
            var tags = categurizer.GetTags(rectangle);


            // Assert
            tags.Should().NotBeNull();
            tags.Should().HaveCount(1);
            tags.First().Should().Be("Flat");
        }


        [Theory]
        [InlineData(10,20)]
        [InlineData(10,11)]
        [InlineData(10.4,10.5)]
        public void TallRectangles(double width, double height)
        {
            // Arrange
            var categurizer = new RectangleCategorizer();
            var rectangle = new Rectangle(width, height);

            // Act
            var tags = categurizer.GetTags(rectangle);


            // Assert
            tags.Should().NotBeNull();
            tags.Should().HaveCount(1);
            tags.First().Should().Be("Tall");
        }


        [Theory]
        [InlineData(20,20)]
        [InlineData(11,11)]
        [InlineData(10.5,10.5)]
        public void SquareRectangles(double width, double height)
        {
            // Arrange
            var categurizer = new RectangleCategorizer();
            var rectangle = new Rectangle(width, height);

            // Act
            var tags = categurizer.GetTags(rectangle);


            // Assert
            tags.Should().NotBeNull();
            tags.Should().HaveCount(1);
            tags.First().Should().Be("Square");
        }
    }
}

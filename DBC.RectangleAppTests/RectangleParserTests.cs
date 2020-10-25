using DBC.Domain;
using DBC.Domain.Parsers;
using DBC.RectangleApp.Gatherers;
using FluentAssertions;
using Xunit;

namespace DBC.RectangleApp.Tests
{
    public class RectangleParserTests
    {
        [Theory]
        [InlineData("20,10")]
        [InlineData("20, 10")]
        [InlineData("20,   10 ")]
        [InlineData("      20, 10")]
        [InlineData("      20, 10   ")]
        [InlineData("      20   , 10   ")]
        public void ParseCorectInputTest(string input)
        {
            // Arrange
            var parser = new RectangleParser();

            // Act
            var (rectangle, error) = parser.Parse(input);

            // Assert
            error.Should().BeNullOrEmpty();
            rectangle.Should().NotBeNull();
            rectangle.Width.Should().Be(20);
            rectangle.Height.Should().Be(10);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public void ParseEmptyInputTest(string input)
        {
            // Arrange
            var parser = new RectangleParser();

            // Act
            var (rectangle, error) = parser.Parse(input);

            // Assert
            error.Should().Be(messages.EmptyInput);
            rectangle.Should().BeNull();
        }


        [Theory]
        [InlineData("10,20,30")]
        [InlineData("adf")]
        [InlineData("10 20")]
        [InlineData("10.5")]
        public void ParseWrongInputFormatTest(string input)
        {
            // Arrange
            var parser = new RectangleParser();

            // Act
            var (rectangle, error) = parser.Parse(input);

            // Assert
            error.Should().Be(messages.WrongInputFormat);
            rectangle.Should().BeNull();
        }


        [Theory]
        [InlineData(",")]
        [InlineData("abc,efg")]
        [InlineData("10,ab")]
        [InlineData("ab,20")]
        public void ParseWrongInputNumberTest(string input)
        {
            // Arrange
            var parser = new RectangleParser();

            // Act
            var (rectangle, error) = parser.Parse(input);

            // Assert
            error.Should().Be(messages.CanNotConvert);
            rectangle.Should().BeNull();
        }
    }
}
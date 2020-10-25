using DBC.Infrastructure.Extensions;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace DBC.InfrastructureTests
{
    public class StringListExtensionTests
    {
        [Fact]
        public void OneInputTest()
        {
            // Arrange
            var list = new List<string> { "a" };

            // Act
            var result = list.JoinStrings();

            // Assert
            result.Should().Be("a");
        }


        [Fact]
        public void TwoInputTest()
        {
            // Arrange
            var list = new List<string> { "a", "b" };

            // Act
            var result = list.JoinStrings();

            // Assert
            result.Should().Be("a and b");
        }


        [Fact]
        public void ThreeInputTest()
        {
            // Arrange
            var list = new List<string> { "a", "b", "c" };

            // Act
            var result = list.JoinStrings();

            // Assert
            result.Should().Be("a, b and c");
        }


        [Fact]
        public void EmptyInputTest()
        {
            // Arrange
            var list = new List<string> { "a", "b", "", "c" };

            // Act
            var result = list.JoinStrings();

            // Assert
            result.Should().Be("a, b and c");
        }


        [Fact]
        public void MoreInputTest()
        {
            // Arrange
            var list = new List<string> { "a", "b", "", "c", "d", "e" };

            // Act
            var result = list.JoinStrings();

            // Assert
            result.Should().Be("a, b, c, d and e");
        }
    }
}

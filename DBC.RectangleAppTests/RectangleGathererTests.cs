using DBC.Infrastructure;
using DBC.Model;
using DBC.RectangleApp.ConsoleReadAndWriters;
using DBC.RectangleApp.Gatherers;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DBC.RectangleAppTests
{
    public class RectangleGathererTests
    {
        [Fact]
        public void CollectingRectangles()
        {
            // Arrange
            var readAndWriter = A.Fake<IConsoleReadAndWriter>();
            A.CallTo(() => readAndWriter.Read())
                .ReturnsNextFromSequence("10,20", ",10,54", "26,80", "70,90", "f");

            var parser = A.Fake<IRectangleParser>();
            var result = new List<(Rectangle, string)>
            {
                (new Rectangle(10,20), string.Empty),
                (null, "Error"),
                (new Rectangle(26,80), string.Empty),
                (new Rectangle(70,90), string.Empty),
            };
            A.CallTo(() => parser.Parse(A<string>.Ignored))
                .ReturnsNextFromSequence(result.ToArray());

            var gathere = new RectangleGatherer(parser, readAndWriter);

            // Act
            var rectangles = gathere.GetRectangles();

            // Assert
            rectangles.Should().NotBeNullOrEmpty();
            rectangles.Should().HaveCount(3);
            A.CallTo(() => readAndWriter.Write(A<string>.Ignored)).MustHaveHappened(6, Times.Exactly);
            A.CallTo(() => readAndWriter.Read()).MustHaveHappened(5, Times.Exactly);
        }
    }
}

using DBC.Domain.ShapeSorters;
using DBC.Model;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DBC.DomainTests
{
    public class PerimeterSorterTests
    {
        [Fact]
        public void AssendingSortTest()
        {
            // Arrange
            var shapes = new List<Shape>();

            var rectangle1 = new Rectangle(10, 10); // Perimeter = 40
            shapes.Add(rectangle1);

            var rectangle2 = new Rectangle(11, 10); // Perimeter = 42
            shapes.Add(rectangle2);

            var rectangle3 = new Rectangle(10, 12); // Perimeter = 44
            shapes.Add(rectangle3);

            var circle1 = new Circle(10);           // Perimeter ~ 62.8
            shapes.Add(circle1);

            var circle2 = new Circle(5);            // Perimeter ~ 31.4
            shapes.Add(circle2);

            var circle3 = new Circle(8);            // Perimeter ~ 50.3
            shapes.Add(circle3);

            // default setting is ascending
            var sorter = new PerimeterSorter();
            var resultSholdBe = new List<Shape> { circle2, rectangle1, rectangle2, rectangle3, circle3, circle1 };

            // Act
            var sortedShapes = sorter.Sort(shapes);


            // Assert
            sortedShapes.Should().NotBeNullOrEmpty();
            sortedShapes.Should().HaveCount(6);

            var first = sortedShapes.First();
            first.GetType().Name.Should().Be("Circle");
            first.As<Circle>().Radios.Should().Be(5);

            var last = sortedShapes.Last();
            last.GetType().Name.Should().Be("Circle");
            last.As<Circle>().Radios.Should().Be(10);

            sortedShapes.SequenceEqual(resultSholdBe).Should().BeTrue();
        }

        [Fact]
        public void DecsendingSortTest()
        {
            // Arrange
            var shapes = new List<Shape>();

            var rectangle1 = new Rectangle(10, 10); // Perimeter = 100
            shapes.Add(rectangle1);

            var rectangle2 = new Rectangle(11, 10); // Perimeter = 110
            shapes.Add(rectangle2);

            var rectangle3 = new Rectangle(10, 12); // Perimeter = 120
            shapes.Add(rectangle3);

            var circle1 = new Circle(10);           // Perimeter ~ 314
            shapes.Add(circle1);

            var circle2 = new Circle(5);            // Perimeter ~ 78.5
            shapes.Add(circle2);

            var circle3 = new Circle(8);            // Perimeter ~ 201
            shapes.Add(circle3);

            var sorter = new PerimeterSorter();
            sorter.Direction = SortDirection.Descending;
            var resultSholdBe = new List<Shape> { circle1, circle3, rectangle3, rectangle2, rectangle1, circle2 };

            // Act
            var sortedShapes = sorter.Sort(shapes);


            // Assert
            sortedShapes.Should().NotBeNullOrEmpty();
            sortedShapes.Should().HaveCount(6);

            var first = sortedShapes.First();
            first.GetType().Name.Should().Be("Circle");
            first.As<Circle>().Radios.Should().Be(10);

            var last = sortedShapes.Last();
            last.GetType().Name.Should().Be("Circle");
            last.As<Circle>().Radios.Should().Be(5);

            sortedShapes.SequenceEqual(resultSholdBe).Should().BeTrue();
        }
    }
}

using DBC.Infrastructure;
using DBC.Model;
using System;
using DBC.Infrastructure.Extensions;

namespace DBC.RectangleApp.Printers
{
    public class ComplexPrinter : IPrinter
    {
        private readonly Func<Shape, IShapeCategorizer> _categorizerFactory;

        public ComplexPrinter(Func<Shape, IShapeCategorizer> categorizerFactory)
        {
            _categorizerFactory = categorizerFactory;
        }


        public void Print(Shape shape)
        {
            var tagList = _categorizerFactory(shape).GetTags(shape);

            var tags = tagList.JoinStrings();

            tags = string.IsNullOrWhiteSpace(tags) ? "" : $" ({tags})";

            Console.WriteLine($"{shape.Describe}{tags}");
        }
    }
}

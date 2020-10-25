using DBC.Infrastructure;
using DBC.Model;
using System.Collections.Generic;

namespace DBC.Domain.ShapeCategorizers
{
    public class RectangleCategorizer : IShapeCategorizer
    {
        public IEnumerable<string> GetTags(Shape shape)
        {
            var tags = new List<string>();

            if (!(shape is Rectangle rectangle))
                return tags;


            var index = rectangle.Width / rectangle.Height;
            if (index > 1)
                tags.Add("Flat");
            else if (index < 1)
                tags.Add("Tall");
            else
                tags.Add("Square");


            return tags;
        }
    }
}

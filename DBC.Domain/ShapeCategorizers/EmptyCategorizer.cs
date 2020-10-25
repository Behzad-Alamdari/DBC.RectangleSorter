using DBC.Infrastructure;
using DBC.Model;
using System.Collections.Generic;

namespace DBC.Domain.ShapeCategorizers
{
    public class EmptyCategorizer : IShapeCategorizer
    {
        public IEnumerable<string> GetTags(Shape shape)
        {
            return new List<string>();
        }
    }
}

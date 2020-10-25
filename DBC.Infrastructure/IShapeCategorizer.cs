using DBC.Model;
using System.Collections.Generic;

namespace DBC.Infrastructure
{
    public interface IShapeCategorizer
    {
        IEnumerable<string> GetTags(Shape shape);
    }
}

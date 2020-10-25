using DBC.Model;
using System.Collections.Generic;

namespace DBC.Infrastructure
{
    public interface IShapeSorter
    {
        string Name { get; set; }
        IEnumerable<Shape> Sort(IEnumerable<Shape> shapes);
    }
}

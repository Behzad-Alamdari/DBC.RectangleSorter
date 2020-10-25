using DBC.Infrastructure;
using DBC.Model;
using System.Collections.Generic;
using System.Linq;

namespace DBC.Domain.ShapeSorters
{
    public class PerimeterSorter : IShapeSorter, IConfigurableSort
    {
        public SortDirection Direction { get; set; } = SortDirection.Ascending;

        public string Name { get; set; } = "Perimeter Sorter";

        public IEnumerable<Shape> Sort(IEnumerable<Shape> shapes)
        {
            if (Direction == SortDirection.Ascending)
                return shapes.OrderBy(s => s.Perimeter());
            else
                return shapes.OrderByDescending(s => s.Perimeter());
        }
    }
}

using DBC.Infrastructure;
using DBC.Model;
using System.Collections.Generic;
using System.Linq;

namespace DBC.Domain.ShapeSorters
{
    public class AreaSorter : IShapeSorter, IConfigurableSort
    {
        public SortDirection Direction { get; set; } = SortDirection.Ascending;

        public string Name { get; set; } = "Area Sorter";

        public IEnumerable<Shape> Sort(IEnumerable<Shape> shapes)
        {
            if (Direction == SortDirection.Ascending)
                return shapes.OrderBy(s => s.Area());
            else
                return shapes.OrderByDescending(s => s.Area());
        }
    }
}

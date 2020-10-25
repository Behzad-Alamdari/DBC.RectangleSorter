using DBC.Infrastructure;

namespace DBC.RectangleApp.SorterSelectors
{
    public interface ISorterSelector
    {
        IShapeSorter Select();
    }
}
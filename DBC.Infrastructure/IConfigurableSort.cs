using DBC.Model;

namespace DBC.Infrastructure
{
    public interface IConfigurableSort
    {
        SortDirection Direction { get; set; }
    }
}

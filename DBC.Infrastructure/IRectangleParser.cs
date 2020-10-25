using DBC.Model;

namespace DBC.Infrastructure
{
    public interface IRectangleParser
    {
        (Rectangle, string) Parse(string input);
    }
}

using DBC.Domain;
using DBC.Infrastructure;
using DBC.Model;

namespace DBC.Domain.Parsers
{
    public class RectangleParser : IRectangleParser
    {
        public (Rectangle, string) Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return (null, messages.EmptyInput);


            var dimensions = input.Split(',');
            if (dimensions.Length != 2)
                return (null, messages.WrongInputFormat);

            if (double.TryParse(dimensions[0], out var width) && double.TryParse(dimensions[1], out var height))
                return (new Rectangle(width, height), null);
            else
                return (null, messages.CanNotConvert);
        }
    }
}

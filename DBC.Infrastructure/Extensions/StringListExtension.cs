using System.Collections.Generic;
using System.Linq;

namespace DBC.Infrastructure.Extensions
{
    public static class StringListExtension
    {
        public static string JoinStrings(this IEnumerable<string> strings)
        {
            var list = strings.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

            if (!strings.Any())
                return "";

            if (list.Count == 1)
                return list.First();

            if (list.Count == 2)
                return list.Aggregate((a, b) => $"{a} and {b}");

            return $"{list.Take(list.Count - 1).Aggregate((a, b) => $"{a}, {b}")} and {list.Last()}";
        }
    }
}

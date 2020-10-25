using DBC.Infrastructure;
using DBC.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBC.RectangleApp.SortConfigurables
{
    public class SortConfiturere : ISortConfiturere

    {
        private readonly List<SortDirection> _sortDirections;
        public SortConfiturere()
        {
            _sortDirections = Enum.GetValues(typeof(SortDirection)).OfType<SortDirection>().ToList();
        }


        public void Configure(IConfigurableSort configuration)
        {
            Console.WriteLine("Select the direction of sort");
            foreach (var sortDirection in _sortDirections)
                Console.WriteLine($@"To select '{sortDirection}' press {_sortDirections.IndexOf(sortDirection) + 1}{
                    (_sortDirections.IndexOf(sortDirection) == 0 ? " (Default)" : "")}");

            var input = Console.ReadLine();
            var index = 0;
            while (!IsValid(input, out index))
                input = Console.ReadLine();

            configuration.Direction = _sortDirections[index];
        }

        private bool IsValid(string input, out int index)
        {
            // Default sorter
            if (string.IsNullOrWhiteSpace(input))
            {
                index = 0;
                return true;
            }

            // input is pars-able to int
            if (int.TryParse(input, out index))
            {
                // The list index is zero base while the user input is start from one
                index--;

                // input is an invalid number
                if (index < 0 || index > _sortDirections.Count)
                    return false;

                return true;
            }
            else
                return false;
        }
    }
}

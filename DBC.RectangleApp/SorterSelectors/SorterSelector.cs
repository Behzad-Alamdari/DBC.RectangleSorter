using DBC.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBC.RectangleApp.SorterSelectors
{
    public class SorterSelector : ISorterSelector
    {
        private List<IShapeSorter> _sorters;

        public SorterSelector(IServiceProvider serviceProvider)
        {
            _sorters = serviceProvider.GetServices<IShapeSorter>().ToList();
        }

        public IShapeSorter Select()
        {
            Console.WriteLine("Please select the sorter you want and then press enter or just press enter if the default sorter is fine");
            
            // Write all options
            foreach (var sorter in _sorters)
                Console.WriteLine(@$"To select '{sorter.Name}' press {_sorters.IndexOf(sorter) + 1}{
                    (_sorters.IndexOf(sorter) == 0 ? " (Default)" : "")}");

            // Read the selected option
            var input = Console.ReadLine();

            // Try to read until getting a correct input
            var index = 0;
            while (!IsValid(input, out index))
                input = Console.ReadLine();

            // return selected sorter
            return _sorters[index];
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
                if (index < 0 || index > _sorters.Count)
                    return false;

                // input is valid
                return true;
            }
            else
                // input can not be parsed to integer
                return false;
        }
    }
}

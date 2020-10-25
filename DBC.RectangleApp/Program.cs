using DBC.Infrastructure;
using DBC.RectangleApp.Gatherers;
using DBC.RectangleApp.Printers;
using DBC.RectangleApp.SortConfigurables;
using DBC.RectangleApp.SorterSelectors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DBC.RectangleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Container 
            // All types are registered within this container
            var provider = Startup.BuildProvider();

            // Helper class which reads data inputed by user
            var rectangleGatherer = provider.GetRequiredService<IRectangleGatherer>();
            var rectangles = rectangleGatherer.GetRectangles();

            // Select the sort class
            var sorterSelector = provider.GetRequiredService<ISorterSelector>();
            var sorter = sorterSelector.Select();

            // If sorter can be configure
            if (sorter is IConfigurableSort configurableSort)
            {
                // A helper which by gathering user input, configure the sorter
                var sortConfigurere = provider.GetRequiredService<ISortConfiturere>();
                sortConfigurere.Configure(configurableSort);
            }

            // Actual sorting
            var sortedRectangles = sorter.Sort(rectangles);

            // Printer factory, which help to chose write printer according to settings
            var printerFactory = provider.GetRequiredService<Func<IPrinter>>();
            var printer = printerFactory();

            // Print all rectangles in console
            sortedRectangles.ToList().ForEach(s => printer.Print(s));
        }
    }
}

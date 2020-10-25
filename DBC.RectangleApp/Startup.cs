using DBC.Domain.Parsers;
using DBC.Domain.ShapeCategorizers;
using DBC.Domain.ShapeSorters;
using DBC.Infrastructure;
using DBC.Model;
using DBC.RectangleApp.ConsoleReadAndWriters;
using DBC.RectangleApp.Gatherers;
using DBC.RectangleApp.Printers;
using DBC.RectangleApp.SortConfigurables;
using DBC.RectangleApp.SorterSelectors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DBC.RectangleApp
{
    public class Startup
    {
        public static IServiceProvider BuildProvider()
        {
            var services = new ServiceCollection();

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var printerConfig = config.GetSection("MyConfig:PrinterSettings").Get<PrinterConfig>();
            services.AddSingleton(printerConfig);

            services.AddTransient<IRectangleGatherer, RectangleGatherer>();
            services.AddTransient<IRectangleParser, RectangleParser>();
            services.AddTransient<IShapeSorter, AreaSorter>();
            services.AddTransient<IShapeSorter, PerimeterSorter>();
            services.AddTransient<ISorterSelector, SorterSelector>();
            services.AddTransient<ISortConfiturere, SortConfiturere>();
            services.AddTransient<IConsoleReadAndWriter, ConsoleReadAndWriter>();

            services.AddTransient<RectangleCategorizer>();
            services.AddTransient<EmptyCategorizer>();
            services.AddTransient(provider =>
            {
                Func<Shape, IShapeCategorizer> factory = (Shape shape) =>
                {
                    switch (shape)
                    {
                        case Rectangle rectangle:
                            return provider.GetRequiredService<RectangleCategorizer>();
                        default:
                            return provider.GetRequiredService<EmptyCategorizer>();
                    }
                };

                return factory;
            });


            services.AddTransient<SimplePrinter>();
            services.AddTransient<ComplexPrinter>();
            services.AddTransient(provider =>
            {
                var config = provider.GetRequiredService<PrinterConfig>();

                Func<IPrinter> factory = () =>
                {
                    switch (config.Name)
                    {
                        case "complex":
                            return provider.GetRequiredService<ComplexPrinter>();
                        case "simple":
                        default:
                            return provider.GetRequiredService<SimplePrinter>();
                    }
                };

                return factory;
            });


            return services.BuildServiceProvider();
        }
    }
}

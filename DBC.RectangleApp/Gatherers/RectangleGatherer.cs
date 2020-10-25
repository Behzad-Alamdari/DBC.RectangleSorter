using DBC.Infrastructure;
using DBC.Model;
using DBC.RectangleApp.ConsoleReadAndWriters;
using System.Collections.Generic;

namespace DBC.RectangleApp.Gatherers
{
    public class RectangleGatherer : IRectangleGatherer
    {
        private readonly IRectangleParser _parser;
        private readonly IConsoleReadAndWriter _readAndWriter;

        public RectangleGatherer(IRectangleParser parser, IConsoleReadAndWriter readAndWriter)
        {
            _parser = parser;
            _readAndWriter = readAndWriter;
        }


        public List<Rectangle> GetRectangles()
        {
            var rectangles = new List<Rectangle>();

            foreach (var rectangle in Gather())
                rectangles.Add(rectangle);

            return rectangles;
        }

        private IEnumerable<Rectangle> Gather()
        {
            _readAndWriter.Write("You can input as many rectangles as you wish.");
            _readAndWriter.Write("Your input should be in the following format.");
            _readAndWriter.Write("When you finish inputing press 'f' or 'F'.");
            _readAndWriter.Write("with, height\n\n");


            _readAndWriter.Write("Please enter the width and height of rectangles");


            var input = _readAndWriter.Read();
            while (input?.ToLower() != "f")
            {
                var (rectangel, error) = _parser.Parse(input);

                if (!string.IsNullOrWhiteSpace(error))
                    _readAndWriter.Write(error);
                else
                    yield return rectangel;

                input = _readAndWriter.Read();
            }
        }
    }
}

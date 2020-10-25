using DBC.Model;
using System;

namespace DBC.RectangleApp.Printers
{
    public class SimplePrinter : IPrinter
    {
        public void Print(Shape shape)
        {
            Console.WriteLine(shape.Describe);
        }
    }
}

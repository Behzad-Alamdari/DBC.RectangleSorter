using System;

namespace DBC.Model
{
    public class Circle : Shape
    {
        public double Radios { get; private set; }

        public override string Describe => $"Circle - Radios: {Radios}";

        public Circle(double radios)
        {
            Radios = radios;
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Radios;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(Radios, 2);
        }
    }
}

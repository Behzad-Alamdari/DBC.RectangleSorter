using System.Collections.Generic;

namespace DBC.Model
{
    public abstract class Shape
    {
        public abstract double Area();

        public abstract double Perimeter();

        public abstract string Describe { get; }
    }
}

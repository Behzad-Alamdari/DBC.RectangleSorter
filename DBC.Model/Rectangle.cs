namespace DBC.Model
{
    public class Rectangle : Shape
    {
        public double Height { get; private set; }
        public double Width { get; private set; }

        public override string Describe => $"Rectangle - Width: {Width}, Height: {Height}";

        public Rectangle(double width, double height)
        {
            Height = height;
            Width = width;
        }


        public override double Area()
        {
            return Height * Width;
        }

        public override double Perimeter()
        {
            return 2 * (Height + Width);
        }
    }
}

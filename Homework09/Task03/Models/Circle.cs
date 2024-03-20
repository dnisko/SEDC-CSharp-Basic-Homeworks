using System.Globalization;

namespace Task03.Models
{
    /*
      Add class Circle, that inherits from Shape.
       It should have property radius.
       Override the getArea and getPerimeter methods correspondingly for a circle.
     */
    internal class Circle : Shape
    {
        public decimal Radius { get; set; }

        public Circle(string name, string color, int[] position, decimal radius)
            : base(name, color, position)
        {
            Radius = radius;
        }

        public override string GetArea()
        {
            //Math.PI * Math.Pow(radius, 2)
            decimal area = (decimal)Math.PI * (Radius * Radius);
            return $"The {Color} Circle {Name} with radius: {Radius} has an area of:{area.ToString(CultureInfo.InvariantCulture)}";
        }

        public override string GetPerimeter()
        {
            decimal perimeter = 2 * (decimal)Math.PI * Radius;//2 * 3.14m * Radius;
            return $"The {Color} Rectangle {Name} with radius: {Radius} has a perimeter of:{perimeter.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}

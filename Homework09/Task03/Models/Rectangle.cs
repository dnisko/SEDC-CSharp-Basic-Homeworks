using System.Globalization;

namespace Task03.Models
{
    /*
     Add class Rectangle, that inherits from Shape. It should have properties sideA and sideB. Override the getArea and getPerimeter
       methods correspondingly for a rectangle.
     */
    internal class Rectangle : Shape
    {
        public decimal SideA { get; set; }
        public decimal SideB { get; set; }

        public Rectangle(string name, string color, int[] position, decimal sideA, decimal sideB)
            : base(name, color, position)
        {
            SideA = sideA;
            SideB = sideB;
        }

        public override string GetArea()
        {
            decimal area = SideA * SideB;
            return $"The {Color} Rectangle {Name} with sideA: {SideA} and sideB: {SideB} has an area of:{area.ToString(CultureInfo.InvariantCulture)}";
        }

        public override string GetPerimeter()
        {
            decimal perimeter = (2 * SideA) + (2 * SideB);
            return $"The {Color} Rectangle {Name} with sideA: {SideA} and sideB: {SideB} has a perimeter of:{perimeter.ToString(CultureInfo.CurrentCulture)}";
        }
    }
}

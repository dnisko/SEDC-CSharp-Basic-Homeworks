using Task03.Models;

namespace Task03
{
    internal class Program
    {
        #region Task 3

        /*
         Bonus Task(not mandatory)

        Create a class Shape that has:
        Name
        Color
        Position, array of x and y coordinates (int[])
        getArea - method that will only write in the console that there is no special implementation for area
        getPerimeter - method that will only write in the console that there is no special implementation for perimeter

         *add method move that is shared among all instances and can be accessed through the class name.
         * It updates the position of the input, by increasing the coordinates for 5.

        create a setter and getter for the color and name property. The setter/getter will log a corresponding message. The setter should do validation.
        
        Add class Rectangle, that inherits from Shape. It should have properties sideA and sideB. Override the getArea and getPerimeter
        methods correspondingly for a rectangle.
        
        Add class Circle, that inherits from Shape.
        It should have property radius.
        Override the getArea and getPerimeter methods correspondingly for a circle.
        Test with few objects

         */

        #endregion
        static void Main(string[] args)
        {
            Circle c1 = new Circle("Circle1", "Red", new []{40, 30}, 10);
            Circle c2 = new Circle("Circle2", "Green", new []{50, 50}, 20);
            Circle c3 = new Circle("Circle3", "Blue", new []{10, 50}, 30);

            Rectangle r1 = new Rectangle("Rectangle1", "Red", new[] { 50, 60 }, 13.5m, 25);
            Rectangle r2 = new Rectangle("Rectangle2", "Green", new[] { 20, 60 }, 18m, 25.8m);
            Rectangle r3 = new Rectangle("Rectangle3", "Blue", new[] { 80, 50 }, 16m, 28.2m);

            Console.WriteLine(c1.GetArea());
            Console.WriteLine(c1.GetPerimeter() + "\n");

            Console.WriteLine(c2.GetArea());
            Console.WriteLine(c2.GetPerimeter() + "\n");

            Console.WriteLine(c3.GetArea());
            Console.WriteLine(c3.GetPerimeter() + "\n");

            Console.WriteLine(r1.GetArea());
            Console.WriteLine(r1.GetPerimeter() + "\n");

            Console.WriteLine(r2.GetArea());
            Console.WriteLine(r2.GetPerimeter() + "\n");

            Console.WriteLine(r3.GetArea());
            Console.WriteLine(r3.GetPerimeter());
        }
    }
}

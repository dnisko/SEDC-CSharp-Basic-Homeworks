namespace Task03.Models
{
    /*
      Create a class Shape that has:
       Name
       Color
       Position, array of x and y coordinates (int[])
       getArea - method that will only write in the console that there is no special implementation for area
       getPerimeter - method that will only write in the console that there is no special implementation for perimeter
        *add method move that is shared among all instances and can be accessed through the class name.
        * It updates the position of the input, by increasing the coordinates for 5.
     */
    internal class Shape
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int[] Position { get; set; }

        public Shape(string name, string color, int[] position)
        {
            Name = name;
            Color = color;
            Position = position;
        }

        public virtual string GetArea()
        {
            return "there is no special implementation for area";
        }

        public virtual string GetPerimeter()
        {
            return "there is no special implementation for perimeter";
        }

        public void Move()
        {
            Position[0] += 5;
            Position[1] += 5;
        }
    }
}

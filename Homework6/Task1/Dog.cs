using System.Drawing;

namespace Task1
{
    #region Task1

    /*
    Task 1

    Create a class Dog
    Add properties: Name, breed, color
    The dog needs to have an Eat method that returns a message: The dog is now eating.
    A Play method returning a message : The dog is now playing.
    And a ChaseTail method that returns a message: The dog is now chasing it's tail.
    The user needs to create a dog object by using inputs from the console and then choose an option to choose one of the methods mentioned above.
    For example, if he enters 1 to call the Eat method, if he enters 2 to call the Play method or if the user enters 3 to call the ChaseTail method.

    */
    #endregion
    public class Dog
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }

        public Dog(string name, string breed, string color)
        {
            Name = name;
            Breed = breed;
            Color = color;
        }
        public string Eat()
        {
            return $"The dog {Name} of breed {Breed} {Color} is now eating.";
        }

        public string Play()
        {
            return $"The dog {Name} of breed {Breed} {Color} is now playing.";
        }

        public string ChaseTail()
        {
            return $"The dog {Name} of breed {Breed} of color {Color} is now chasing it's tail.";
        }
    }
}

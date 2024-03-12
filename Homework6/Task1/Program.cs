using System.Diagnostics;
using System.Drawing;

namespace Task1
{
    internal class Program
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
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter name for the dog");
            //string name = Console.ReadLine();

            //Console.WriteLine("Enter breed for the dog");
            //string breed = Console.ReadLine();

            //Console.WriteLine("Enter color for the dog");
            //string color = Console.ReadLine();

            //Dog dog1 = new Dog(name, breed, color);

            //Console.WriteLine("Enter number from 1 to 3.");
            //string option = Console.ReadLine();
            //int option = GetOptionFromInput();


            //switch (option)
            //{
            //    case 1: Console.WriteLine(dog1.Eat());
            //        break;
            //    case 2: Console.WriteLine(dog1.Play());
            //        break;
            //    case 3: Console.WriteLine(dog1.ChaseTail());
            //        break;
            //    default: Console.WriteLine("Wrong data entered");
            //        break;
            //}

            Dog dog2 = new Dog(
                GetStringInputFromConsole("Enter name for the dog"),
                GetStringInputFromConsole("Enter breed for the dog"),
                GetStringInputFromConsole("Enter color for the dog"));
            
            Console.WriteLine("Enter number from 1 to 3.");
            int option = GetOptionFromInput();
            Console.WriteLine(GetDogAction(option, dog2));
        }

        public static string GetStringInputFromConsole(string displayMessage)
        {
            Console.WriteLine(displayMessage);
            string input = Console.ReadLine();

            return input;
        }

        public static int GetOptionFromInput()
        {
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    continue;
                }
                return option;
            }
        }

        public static string GetDogAction(int option, Dog dog)
        {
            switch (option)
            {
                case 1: 
                    return dog.Eat();
                case 2:
                    return dog.Play();
                case 3:
                    return dog.ChaseTail();
                default:
                    return "Wrong data entered";
            }
        }
    }
}

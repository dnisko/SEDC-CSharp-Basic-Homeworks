using System.Text.RegularExpressions;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task4
            /*
            Task 4
            
            Create an array with names
            Give an option to the user to enter a name from the keyboard
            After entering the name put it in the array
            Ask the user if they want to enter another name(Y / N)
            Do the same process over and over until the user enters N
            Print all the names after user enters N
            */
            #endregion


            string[] names = { };

            while (true)
            {
                Console.WriteLine("Enter name:");
                string input = Console.ReadLine();

                Array.Resize(ref names, names.Length + 1);
                names[names.Length - 1] = input;

                Console.WriteLine("Do you want to enter another number y/n?");
                string input1 = Console.ReadLine();

                if (input1 != "y" && input1 != "Y")
                {
                    break;
                }
            }
            Console.WriteLine("The names you entered are:");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}

using System.Globalization;
using System.Text;

namespace Task1
{
    internal class Program
    {
        #region Task1

        /*
         Task 1
           
           Create a method called NumberStats that accepts a number. This method should:
           
               Find out if the number is negative or positive
           
               Find out if the number is odd or even
           
               Find out if the number is decimal or integer
           
               After finding all the stats it should print them like this:
           
               Stats for number: 25
                   Positive
                   Integer
                   Odd
           
           The number should be entered in the console by the user.
           
           Bonus: Validate if the user is entering a number
           
           Bonus: Ask the user to press Y to try again or X to exit
         */

        #endregion

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string tryAgain = "";
            while (tryAgain.ToLower() != "x")
            {
                Console.WriteLine("Enter number for stats:");
                decimal number;
                //string input = Console.ReadLine();
                while (true)
                {
                    //the !double.TryParse(Console.ReadLine(), out number) - always returns integer... ex. input: 25.5, number = 255....
                    //found this snippet somewhere on the net :)
                    if (!decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out number))
                    {
                        Console.WriteLine("Please enter a number.");
                        continue;
                    }

                    break;
                }

                string result = NumberStats(number.ToString(new CultureInfo("en-US")));
                Console.WriteLine(result);


                Console.WriteLine("\nDo you want to try again (enter: 'y' or 'x')?");
                string answer = Console.ReadLine();

                while (answer != "y" && answer != "x")
                {
                    Console.WriteLine("Wrong input, enter 'y' or 'x'");

                    Console.WriteLine("\nDo you want to try again (enter: 'y' or 'x')?");
                    answer = Console.ReadLine().ToLower();
                }

                if (answer == "x")
                {
                    Console.WriteLine("Goodbye");
                    break;
                }
            }
        }

        public static string NumberStats(string input)
        {
            string result = $"Stats for the number: {input}\n";

            if (input.Contains('.')) 
            {
                result += "Decimal\n";
            }
            else
            {
                result += "Integer\n";
            }

            result += input[0] == '-' ? "Negative\n" : "Positive\n";
            result += Math.Ceiling(decimal.Parse(input)) % 2 == 0 ? "Even\n" : "Odd\n";

            return result;
        }
        /*
        static void Main1(string[] args)
        {
            while (true)
            {


                Console.WriteLine("enter");
                if (!double.TryParse(Console.ReadLine(), out double result))
                {
                    Console.WriteLine(result);
                }

                Console.WriteLine($"{result % 1}");
            }
        }
        */
    }
}

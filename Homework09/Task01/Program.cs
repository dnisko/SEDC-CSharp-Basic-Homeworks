namespace Task01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task1

            /*
             Task 1

               Give the user an option to input numbers
               After inputting each number ask them if they want to input another with a Y/N question
               Store all numbers in a QUEUE
               When the user is done adding numbers print the number in the order that the user entered them from the QUEUE

             */

            #endregion
            Queue<int> inputNumbers = new Queue<int>();
            while (true)
            {
                Console.WriteLine("Enter number:");
                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("Wrong input. Try again.");
                    continue;
                }

                inputNumbers.Enqueue(input);
                Console.WriteLine("Would you like to enter another number? (y/n)");
                string inputForAnotherNumber = Console.ReadLine();

                if (inputForAnotherNumber.ToLower() == "y")
                {
                    continue;
                }

                //if (inputForAnotherNumber.ToLower() == "n")
                //{
                    break;
                //}

                //if (inputForAnotherNumber.ToLower() != "n")
                //{
                //    Console.WriteLine("Wrong input. Enter y or n.");

                //    continue;
                //}

                //break;
            }

            Console.WriteLine($"You entered the numbers:");
            foreach (int number in inputNumbers)
            {
                Console.WriteLine(number);
            }

        }
    }
}

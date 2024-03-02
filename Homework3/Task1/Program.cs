namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Exercise 01 and Homework Task 2 are the same
            /*
                01 EXERCISE
                ● Get an input number from the console
                ● Print all numbers from 1 to that number
                ● Get another input number from the console
                ● Print all numbers from that number to 1
            */
            #endregion

            int number1, number2;

            while (true)
            {
                Console.WriteLine("Please enter first number: ");
                bool input = int.TryParse(Console.ReadLine(), out number1);

                if ((input))
                {
                    break;
                }

                Console.WriteLine("Wrong input");
            }

            Console.WriteLine($"The number entered is: {number1}");

            for (int i = 1; i <= number1; i++)
            {
                Console.WriteLine(i);
            }

            while (true)
            {
                Console.WriteLine("Please enter second number: ");
                bool input = int.TryParse(Console.ReadLine(), out number2);
                if ((input))
                {
                    break;
                }

                Console.WriteLine("Wrong input");
            }

            Console.WriteLine($"The number entered is: {number2}");

            for (int i = number2; i >= 1 ; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}

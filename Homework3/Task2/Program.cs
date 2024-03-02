namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Exercise 02
            /*
                02 EXERCISE
               ● Get an input number from the console
               ● Print all even numbers starting from 2
               ● Get another input number from the console
               ● Print all odd numbers starting from 1
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

            #region Case1
            //for (int i = 2; i <= number1; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}
            #endregion

            #region Case2

            for (int i = 2; i <= number1; i++)
            {
                Console.WriteLine(i);
                i++;
            }

            #endregion

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
            
            #region Case1
            //for (int i = 1; i <= number2; i++)
            //{
            //    if (i % 2 != 0)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}
            #endregion

            #region Case2

            for (int i = 1; i <= number2; i++)
            {
                Console.WriteLine(i);
                i++;
            }

            #endregion
        }
    }
}

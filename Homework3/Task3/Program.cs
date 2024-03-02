namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Homework Task 1

            /*
            Task 1

            Create a new console application “RealCalculator” that takes two numbers from the console and asks what operation would the user want to be
            done ( +, - , * , / ). Then it returns the result. Use a switch statement.
            
             */

            #endregion

            int number1;
            int number2;
            
            while (true)
            {
                Console.WriteLine("Please enter first number: ");
                bool input1 = int.TryParse(Console.ReadLine(), out number1);

                Console.WriteLine("Please enter second number: ");
                bool input2 = int.TryParse(Console.ReadLine(), out number2);

                if ((input1) || (input2))
                {
                    bool isTrue = true;
                    while (isTrue)
                    {
                        Console.WriteLine("Enter the Operation: ");
                        string operation = Console.ReadLine();
                        int result;
                        switch (operation)
                        {
                            case "+":
                                result = number1 + number2;
                                Console.WriteLine($"{number1} {operation} {number2} = {result}");
                                isTrue = false;
                                break;
                            case "-":
                                result = number1 - number2;
                                Console.WriteLine($"{number1} {operation} {number2} = {result}");
                                isTrue = false;
                                break;
                            case "*":
                                result = number1 * number2;
                                Console.WriteLine($"{number1} {operation} {number2} = {result}");
                                isTrue = false;
                                break;
                            case "/":
                                result = number1 / number2;
                                Console.WriteLine($"{number1} {operation} {number2} = {result}");
                                isTrue = false;
                                break;
                            default:
                                Console.WriteLine("Wrong input, please enter operator + - / or *");
                                break;
                        }
                    }
                    break;
                }

                Console.WriteLine("Wrong input, please try again.");
            }
        }
    }
}

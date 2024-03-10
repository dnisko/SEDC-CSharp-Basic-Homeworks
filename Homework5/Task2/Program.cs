namespace Task2
{
    internal class Program
    {
        #region Task2

        /*
        Task 2

        Create a new console application and a new method called Substrings
        In that method enter the following string :
        "Hello from SEDC Codecademy 2024"
        Ask the user to enter a number n.
        Print the first n characters from that string and print the length of the new string.
        Try to handle all the scenarios
        */

        #endregion
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter number to resize the string:");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int n))
                {
                    Console.WriteLine("Wrong input, please try again");
                    continue;
                }

                string result = Substrings(n);
                if (result == "-1")
                {
                    Console.WriteLine("The number is negative, bigger or equal to the string. Try again.\n");
                    continue;
                }

                Console.WriteLine(result);

                break;
            }
        }

        public static string Substrings(int n)
        {
            string originalString = "Hello from SEDC Codecademy 2024.";
            

            if (n >= originalString.Length || n <= 0)
            {
                return  "-1";
            }

            string substring = originalString.Substring(n);
            return $"The original string: |{originalString}|\n" +
                   $"The original Length: {originalString.Length}\n\n" +
                   $"New string: |{substring}|\n" +
                   $"Length: {substring.Length}";
        }
    }
}

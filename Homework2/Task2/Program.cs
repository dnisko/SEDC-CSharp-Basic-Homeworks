namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input1, input2;
            Console.WriteLine("Enter number 1: ");
            bool inNumber1 = int.TryParse(Console.ReadLine(), out input1);

            Console.WriteLine("Enter number 2: ");
            bool inNumber2 = int.TryParse(Console.ReadLine(), out input2);

            Console.WriteLine($"The first number is: {input1}\n" +
                              $"The second number is: {input2}");

            int swapping = input1;
            input1 = input2;
            input2 = swapping;

            //Intellisense  helped :)
            //(input1, input2) = (input2, input1);

            Console.WriteLine("After swapping:");
            Console.WriteLine($"The first number is: {input1}\n" +
                              $"The second number is: {input2}");
        }
    }
}
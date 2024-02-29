namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input1, input2, input3, input4;
            Console.WriteLine("Enter number 1: ");
            bool inNumber1 = int.TryParse(Console.ReadLine(), out input1);

            Console.WriteLine("Enter number 2: ");
            bool inNumber2 = int.TryParse(Console.ReadLine(), out input2);

            Console.WriteLine("Enter number 3: ");
            bool inNumber3 = int.TryParse(Console.ReadLine(), out input3);

            Console.WriteLine("Enter number 4: ");
            bool inNumber4 = int.TryParse(Console.ReadLine(), out input4);


            int sum = input1 + input2 + input3 + input4;
            int average = sum / 4;

            Console.WriteLine($"The average of the numbers entered is: {average}");
        }
    }
}
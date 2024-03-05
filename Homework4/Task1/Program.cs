namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task1
            /*
            Task 1
                           
            Make a console application called SumOfEven.
            Inside it create an array of 6 integers.
            Get input numbers from the console and push them to the array.
            Find and print the sum of the even numbers from the array:
            
                Test Data:
                    Enter integer no.1:
                        4
                    Enter integer no.1:
                        3
                    Enter integer no.1:
                        7
                    Enter integer no.1:
                        3
                    Enter integer no.1:
                        2
                    Enter integer no.1:
                        8
                Expected Output:
                    The result is: 14
             */
            #endregion

            int[] numbers = new int[0];

            do
            {
                Console.WriteLine("Please enter a number:");
                string input = Console.ReadLine();

                if(!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Wrong input, please try again");
                    continue;
                }

                Array.Resize(ref numbers, numbers.Length + 1);
                numbers[numbers.Length - 1] = number;

                //Console.WriteLine("Do you want to enter another number y/n?");
                //string input1 = Console.ReadLine();

                //if(input1 != "y" && input1 != "Y")
                //{
                //    break;
                //}

                if (numbers.Length == 6)
                {
                    break;
                }

            }
            while (true);


            int sum = 0;
            foreach(int number in numbers)
            {
                if (number % 2 == 0)
                {
                    sum += number;
                }

                //Console.WriteLine(number + " " + sum);
            }
            //int sum = numbers.Sum();

            Console.WriteLine($"Sum is: {sum}");
        }
    }
}

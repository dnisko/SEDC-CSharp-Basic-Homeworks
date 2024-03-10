using System.Text.RegularExpressions;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task1

            /*
            Task 1

            Make a method called AgeCalculator
            The method will have one input parameter, your birthday date
            The method should return your age
            Show the age of a user after he inputs a date

            Note: take into consideration if the birthday is today, after or before today
            */

            #endregion

            while (true)
            {
                Console.WriteLine("Enter your birth date");
                string inputDate = Console.ReadLine();

                DateTime checkDate;

                if (!DateTime.TryParse(inputDate, out checkDate))
                {
                    Console.WriteLine("Wrong date inserted. Try again!\n");
                    continue;
                }

                int result = AgeCalculator(checkDate);

                if (result <= 0)
                {
                    Console.WriteLine("You are from the future!?\n");
                    continue;
                }

                Console.WriteLine($"Your birthdate is {inputDate} and you are {result} years old.");

                break;
            }

        }

        public static int AgeCalculator(DateTime a)
        {
            int currentDate = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int input = int.Parse(a.ToString("yyyyMMdd"));

            //converting the dates in yyyyMMdd to easily subtract and divide by
            //10000 to get the years difference, hence the age :)
            return (currentDate - input) / 10000;
        }
    }
}

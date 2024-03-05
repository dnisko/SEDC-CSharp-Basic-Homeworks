namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task2
            /*
            Task 2
               Make a new console application called StudentGroup
               Make 2 arrays called studentsG1 and studentsG2 and fill them with 5 student names.
               Get a number from the console between 1 and 2 and print the students from that group in the console.
               
            Ex: studentsG1 ["Zdravko", "Petko", "Stanko", "Branko", "Trajko"]
               
               Test Data:
               Enter student group: (there are 1 and 2)
                       1
               Expected Output:
               The Students in G1 are:
                   Zdravko
                   Petko
                   Stanko
                   Branko
                   Trajko
               
             */
            #endregion


            string[] g1Group = new string[0];
            string[] g2Group = new string[0];

            do
            {
                Console.WriteLine("Enter name for G1 group:");
                string input = Console.ReadLine();

                Array.Resize(ref g1Group, g1Group.Length + 1);
                g1Group[g1Group.Length - 1] = input;


                if (g1Group.Length == 5)
                {
                    break;
                }

            }
            while (true);

            while (true)
            {
                Console.WriteLine("Enter name for G2 group:");
                string input = Console.ReadLine();

                Array.Resize(ref g2Group, g2Group.Length + 1);
                g2Group[g2Group.Length - 1] = input;


                if (g2Group.Length == 5)
                {
                    break;
                }
            }

            string inputForPrint;
            while (true)
            {
                Console.WriteLine("Enter number of group to print it (1 / 2):");
                inputForPrint = Console.ReadLine();

                if (inputForPrint != "1" && inputForPrint != "2")
                {
                    Console.WriteLine("Enter number 1 or 2");
                    continue;
                }

                break;
            }


            if(inputForPrint == "1")
            {
                Console.WriteLine("The students in G1 group are:");
                foreach(string student in  g1Group)
                {
                    Console.WriteLine(student);
                }
            }

            if(inputForPrint == "2")
            {
                Console.WriteLine("The students in G2 group are:");
                foreach(string student in  g2Group)
                {
                    Console.WriteLine(student);
                }
            }
        }
    }
}

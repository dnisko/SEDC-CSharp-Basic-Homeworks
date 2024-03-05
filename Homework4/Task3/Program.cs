namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task3
            /*
            Task 3
            Declare 5 arrays with 5 elements in them:
               
            With words
            With decimal values
            With characters from keyboard
            With true/false values
            With arrays, each holding 2 whole numbers
             */
            #endregion

            string[] words = new string[5] { "word1", "word2", "word3", "word4", "word5" };
            decimal[] decimals = new decimal[] { 1.2m, 1.3m, 1.5m, 1.6m, 1.5m};
            char[] charachters = new[] { 'a', 'b', 'c', 'd', 'e' };
            bool[] bools = { true, false, true, false, true};
            int[,] arrays =  { {1, 2}, {3, 4}, {5, 6}, {7, 8} };
        }
    }
}

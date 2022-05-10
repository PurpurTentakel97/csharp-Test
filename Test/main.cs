/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Main
 * C# v. 10.0
 */


namespace Test
{
    class Program
    {
        static int listCount = 0;
        static void Main(string[] args)
        {



        }

        private static void PrintBreak()
        {
            Console.WriteLine("|----------------------------------------------------------------------------------------------------|");
        }

        private static void PrintListCount()
        {
            Console.WriteLine("Liste " + listCount.ToString());
            listCount++;
        }

    }
}
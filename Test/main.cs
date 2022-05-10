/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Main
 * C# v. 10.0
 */

using Lists;


namespace Test
{
    class Program
    {
        static string countName = "Baum";
        static int count = 0;
        static void Main(string[] args)
        {
            var entry = new string[] { "a", "b", "c", "d", "d" };

            PrintCount();
            var list_1 = new LinkedList();
            list_1.Print();
            PrintBreak();

            PrintCount();
            var list_2 = new LinkedList(entry);
            list_2.Print();
            PrintBreak();
        }

        private static void PrintBreak()
        {
            Console.WriteLine("|----------------------------------------------------------------------------------------------------|");
        }

        private static void PrintCount()
        {
            Console.WriteLine(countName + " " + count.ToString());
            count++;
        }

    }
}
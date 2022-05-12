/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Tree
 */

using Helpers;

namespace Tree
{
    internal class ChristmasTree
    {
        public void Game()
        {
            while (true)
            {
                Print();

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }
        public void Print()
        {
            byte height = GetInput();
            int leaves = 1;
            for (int i = 0; i < height - 1; i++)
            {
                for (int j = i; j < height - 2; j++)
                {
                    Console.Write(" ");
                }

                for (int k = 0; k < leaves; k++)
                {
                    Console.Write("*");
                }
                leaves += 2;
                Console.WriteLine();
            }
            for (int i = 0; i < height / 10 + 1; i++)
            {
                for (int j = 0; j < height - 2; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }
        }
        private byte GetInput()
        {
            while (true)
            {
                Console.WriteLine("Gib die höhe des Baums ein (<256)");
                string inputRaw = Console.ReadLine();
                if (!byte.TryParse(inputRaw, out byte input))
                {
                    Console.WriteLine("Invalider Input");
                    continue;
                }
                if (input < 3)
                {
                    Console.WriteLine("Invalider Input");
                    continue;
                }
                return input;
            }
        }
    }
}

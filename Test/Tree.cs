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
                Helper.PrintHeadline("Weihnachtsbaum");

                byte height = Helper.GetByte("Gib die Höhe des baumes an.");
                Print(height);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }
        public void Print(byte height)
        {
            int leaves = 1;
            for (int i = 0; i < height - 1; i++)
            {
                for (int j = i; j < height - 2; j++)
                {
                    Console.Write(" ");
                }

                Random rand = new Random();
                for (int k = 0; k < leaves; k++)
                {
                    if (i == 0)
                    {
                        Console.Write("X");
                        continue;
                    }

                    int randInt = rand.Next(0, 1000);
                    if (randInt < 30)
                    {
                        Console.Write("O");
                        continue;
                    }
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
    }
}

/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Strings
 */

using Helpers;

namespace Strings
{
    internal class ReverseString
    {
        public void Game()
        {
            while (true)
            {
                PrintReversedString();

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }

        private void PrintReversedString()
        {
            string value = GetInput();
            char[] chars = value.ToCharArray();
            Array.Reverse(chars);
            Console.WriteLine(new string(chars));
        }

        private string GetInput()
        {
            while (true)
            {
                Console.WriteLine("Gib einen Satz ein.");
                string input = Console.ReadLine();
                if (input is null)
                {
                    Console.WriteLine("Invalider Input");
                    continue;
                }
                if (input.Length == 60000)
                {
                    Console.WriteLine("Invalider Input");
                    continue;
                }
                return input;
            }
        }
    }
}

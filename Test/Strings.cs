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
                Helper.PrintHeadline("Sätze umdrehen");

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
            string value = Helper.GetString("Gib einen Satz ein.");
            char[] chars = value.ToCharArray();
            Array.Reverse(chars);
            Console.WriteLine(new string(chars));
        }
    }
}

/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Numbers
 */

namespace Numbers
{
    internal class PrimeNumbers
    {
        public static void PrintPrimeNumbersTillX(int maxNumber)
        {
            for (int i = 2; i < maxNumber; i++)
            {
                bool found = false;
                for (int j = 2; j < i; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (i % j == 0)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.Write($"{i}, ");
                }

            }
            Console.WriteLine("");
        }

        public static void PrintFirstTenEvenNumbersFor()
        {
            SetConsoleWhite();
            (int left, int top) cursorPosition;
            for (int i = 1; i < 21; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write($"{i}, ");
                    if (i == 18)
                    {
                        cursorPosition = Console.GetCursorPosition();
                        Console.SetCursorPosition(cursorPosition.left - 2, cursorPosition.top);
                        Console.Write(" und ");
                    }
                }
            }
            cursorPosition = Console.GetCursorPosition();
            Console.SetCursorPosition(cursorPosition.left - 2, cursorPosition.top);
            Console.WriteLine(".");
        }
        public static void PrintFirstTenEvenNumbersWhile()
        {
            SetConsoleWhite();
            int index = 1;
            while (index < 21)
            {
                PrintEvenNumber(index: index);
                index++;
            }
            var cursorPosition = Console.GetCursorPosition();
            Console.SetCursorPosition(cursorPosition.Left - 2, cursorPosition.Top);
            Console.WriteLine(".");
        }
        public static void PrintFirstTenEvenNumbersDoWhile()
        {
            SetConsoleWhite();
            int index = 1;
            do
            {
                PrintEvenNumber(index: index);
                index++;
            } while (index < 21);
            var cursorPosition = Console.GetCursorPosition();
            Console.SetCursorPosition(cursorPosition.Left - 2, cursorPosition.Top);
            Console.WriteLine(".");
        }

        public static string ConvertNumberInto8Bit(byte value)
        {
            string ret = "";
            byte bit = 128;
            while (bit > 0)
            {
                if (value >= bit)
                {
                    ret += "1";
                    value -= bit;
                    bit = (byte)((bit) / 2);
                    continue;
                }
                ret += "0";
                bit = (byte)((bit) / 2);
            }
            return ret;

            /* 255 = 11111111
             * 127 = 01111111
             * 63 = 001111111
             * 0 = 00000000
             */
        }

        private static void PrintEvenNumber(int index)
        {
            if (index % 2 == 0)
            {
                Console.Write($"{index}, ");
                if (index == 18)
                {
                    var cursorPosition = Console.GetCursorPosition();
                    Console.SetCursorPosition(cursorPosition.Left - 2, cursorPosition.Top);
                    Console.Write(" und ");
                }
            }
        }

        private static void SetConsoleWhite()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}

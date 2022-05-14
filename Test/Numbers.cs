﻿/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Numbers
 */

using Helpers;
using Menues;

namespace Numbers
{
    internal class PrimeNumbers
    {

        public void Game()
        {

            while (true)
            {
                Helper.PrintHeadline("Prim Zahlen Ausgeben");

                ushort input = Helper.GetUshort("Trage ein bis zu welcher Zahl die Primzahlen ausgegeben werden sollen.");
                PrintPrimeNumbersTillX(input);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }
        private void PrintPrimeNumbersTillX(ushort maxNumber)
        {
            Helper.PrintHeadline("Prim Zahlen Ausgeben");

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
    }

    internal class EvenNumbers
    {
        Menue menue;
        private static (string, Action)[] menueValue = new (string, Action)[]
        {
            ("For-Schleife",PrintFirstTenEvenNumbersFor),
            ("While_schleife",PrintFirstTenEvenNumbersWhile),
            ("Do-While_schleife",PrintFirstTenEvenNumbersDoWhile),
        };


        public EvenNumbers(Menue before)
        {
            menue = new Menue("Gerade Zahlen Ausgeben", menueValue, before);
        }

        public void Game()
        {

            while (true)
            {
                menue.Print();
                Action action = menue.GetAction();
                if (action == null)
                {
                    break;
                }
                action();
            }
        }
        private static void PrintFirstTenEvenNumbersFor()
        {
            Helper.PrintHeadline("For-Schleife");

            (int left, int top) cursorPosition;
            for (int i = 1; i < 12; i++)
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
            Console.ReadLine();
        }
        private static void PrintFirstTenEvenNumbersWhile()
        {
            Helper.PrintHeadline("While-Schleife");

            int index = 1;
            while (index < 21)
            {
                PrintEvenNumber(index: index);
                index++;
            }
            var cursorPosition = Console.GetCursorPosition();
            Console.SetCursorPosition(cursorPosition.Left - 2, cursorPosition.Top);
            Console.WriteLine(".");
            Console.ReadLine();
        }
        private static void PrintFirstTenEvenNumbersDoWhile()
        {
            Helper.PrintHeadline("Do-While-Schleife");

            int index = 1;
            do
            {
                PrintEvenNumber(index: index);
                index++;
            } while (index < 21);
            var cursorPosition = Console.GetCursorPosition();
            Console.SetCursorPosition(cursorPosition.Left - 2, cursorPosition.Top);
            Console.WriteLine(".");
            Console.ReadLine();
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

    }

    internal class GuessNumber
    {
        private byte correctNumber;

        public void Game()
        {

            while (true)
            {
                Helper.PrintHeadline("Zahlen-Raten_Spiel");

                correctNumber = (byte)Random.Shared.Next(0, 101);
                bool win = false;
                byte count = 1;
                byte maxCount = 6;
                do
                {
                    Console.WriteLine($"Runde {count}:");
                    Console.WriteLine($"Verbleivbende Versuche: {maxCount - count + 1}");
                    byte input = Helper.GetByte("Gib deine Vermutung ein (0-100)");
                    if (CheckInput(input))
                    {
                        win = true;
                        break;
                    }
                    count++;
                } while (count <= maxCount);

                if (win)
                {
                    Console.WriteLine($"Glückwunsch Du hast gewonnen. Die richtige Zahl ist {correctNumber}");
                }
                else
                {
                    Console.WriteLine($"Du hast die Zahl leider nicht erraten. Die richtige Zahl wäre {correctNumber} gewesen.");
                }
                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
            Console.WriteLine("Programm beendet.");
        }
        private bool CheckInput(byte input)
        {
            if (correctNumber == input)
            {
                Console.WriteLine("Richtige Zahl");
                return true;
            }

            else if (correctNumber > input)
            {
                Console.WriteLine("Die Zahl ist zu Klein");
                return false;
            }

            Console.WriteLine("Die Zahl ist zu Groß");
            return false;

        }
    }

    internal class MyBitConverter
    {
        public void Game()
        {
            while (true)
            {
                Helper.PrintHeadline("8 Bit Zahlen Konvertieren");

                byte input = Helper.GetByte("Gib die zu konventierenede Zahl ein (< 256)");
                string bit8 = ConvertNumberInto8Bit(input);
                Console.WriteLine(bit8);

                string quitInput = Helper.GetQuitInput();
                if (quitInput == "q")
                {
                    break;
                }
            }
        }

        private string ConvertNumberInto8Bit(byte value)
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
        }
    }
}

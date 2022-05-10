/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Main
 * C# v. 10.0
 */

using Numbers;
using Strings;

namespace Test
{
    class Programm
    {
        static string countName = "Entry";
        static int count = 1;
        static void Main(string[] args)
        {
            ReversingString();
        }

        private static void ReversingString()
        {
            while (true)
            {
                PrintCount();
                Console.WriteLine("Geben Sie etwas ein");
                string? input = Console.ReadLine();
                if (input is null)
                {
                    Console.WriteLine("Kein Eingabe");
                    PrintBreak();
                    continue;
                }
                if (input == "quit")
                {
                    Console.WriteLine("Programm geschlossen");
                    PrintBreak();
                    break;
                }
                ReverseString.PrintReversedString(value: input);
                PrintBreak();
            }

        }
        private static void PrimeNumber()
        {
            while (true)
            {
                PrintCount();
                Console.WriteLine("Geben sie eine Zahl ein. ('quit' um das Programm zu beenden.)");
                string? input = Console.ReadLine();

                if (input == "quit")
                {
                    break;
                }
                if (input is null)
                {
                    Console.WriteLine("keine Eingabe");
                    PrintBreak();
                    continue;
                }

                ushort input_ushort = 0;
                if (!ushort.TryParse(input, out input_ushort))
                {
                    Console.WriteLine("Invalide Eingabe");
                    PrintBreak();
                    continue;
                }

                PrimeNumbers.PrintPrimeNumbersTillX(maxNumber: input_ushort);
                PrintBreak();

            }
            Console.WriteLine("Programm beendet");
        }

        private static void PrintBreak()
        {
            Console.WriteLine("|----------------------------------------------------------------------------------------------------|");
        }

        private static void PrintCount()
        {
            Console.WriteLine($"{countName} {count.ToString()}");
            count++;
        }

    }
}
/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Main
 * C# v. 10.0
 */

using Lists;
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
            PrimeNumber();
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
        private static void List()
        {
            var entry1 = new string[] { "1", "2", "3", "4", "5" };
            var entry2 = new string[] { "a", "b", "c", "d", "e" };
            var entry3 = new string[] { "aa 11 aa", "bb 22 bb", "cc 33 cc", "dd 44 dd", "ee 55 ee" };

            PrintCount();
            var list1 = new LinkedList();
            list1.Print();
            list1.Add(entry3);
            list1.Print();
            Console.WriteLine(list1.Count);
            PrintBreak();

            PrintCount();
            var list2 = new LinkedList();
            list2.Add("123", 20);
            list2.Print();
            Console.WriteLine(list2.Count);
            PrintBreak();
        }

        private static void ConvertByte()
        {
            while (true)
            {
                byte value = GetByte();

                Console.WriteLine(value);
                Console.WriteLine(PrimeNumbers.ConvertNumberInto8Bit(value));
            }
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

        private static byte GetByte()
        {
            while (true)
            {
                Console.WriteLine("Gib eine Zahl ein:");
                string value = Console.ReadLine();
                bool valid = byte.TryParse(value, out byte valueb);
                if (valid)
                {
                    return valueb;
                }
                Console.WriteLine("Ungültige Zahl");
                PrintBreak();
            }
        }

    }
}
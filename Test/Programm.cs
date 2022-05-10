/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Main
 * C# v. 10.0
 */

using Numbers;

namespace Test
{
    class Programm
    {
        static string countName = "Prime Numbers";
        static int count = 1;
        static void Main(string[] args)
        {
            while (true)
            {
                PrintCount();
                Console.WriteLine("Geben sie eine Zahl ein. ('quit' um das Programm zu beenden.)");
                string input = Console.ReadLine();

                if (input == "quit")
                {
                    break;
                }
                if (input is null)
                {
                    Console.WriteLine("keine Zahl eingegeben");
                    continue;
                }

                int input_int = 0;
                try
                {
                    input_int = int.Parse(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("keine Ganzzahlzahl eingegeben");
                    continue;
                }

                PrimeNumbers.PrintPrimeNumbersTillX(maxNumber: input_int);

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
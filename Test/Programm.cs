/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Main
 * C# v. 10.0
 */

using Menues;
using Numbers;

namespace Test
{
    class Programm
    {
        public static (string, Action)[] menueValue = new (string, Action)[]
        {
            ("Zahlen raten",GuessingNumbersF),
            ("Gerade zahlen anzeigen",EvenNumbersF),
            ("Prim Zahlen bis x",PrimeNumbersF),
            ("Zahlen zu Bit convertieren",BitConverterF),
         };

        static void Main(string[] args)
        {
            var menue = new Menue("Menü", menueValue);
            while (true)
            {
                menue.Print();
                var action = menue.GetAction();
                action();
            }
        }

        public static void PrintHeadline(string name)
        {
            string equals = "==========";
            Console.Write(equals);
            for (int i = 0; i < name.Length + 2; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine(equals);

            Console.WriteLine($"{equals} {name} {equals}");

            Console.Write(equals);
            for (int i = 0; i < name.Length + 2; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine(equals);
            Console.WriteLine("");
        }

        private static void GuessingNumbersF()
        {
            Console.Clear();
            PrintHeadline("Zahlen-Raten_Spiel");
            var guessNumbers = new GuessNumber();
            guessNumbers.Game();
            Console.Clear();
        }
        private static void EvenNumbersF()
        {
            Console.Clear();
            PrintHeadline("Zahlen-Raten_Spiel");
            var evenNumebrs = new EvenNumbers();
            evenNumebrs.Game();
            Console.Clear();
        }
        private static void PrimeNumbersF()
        {
            Console.Clear();
            PrintHeadline("Prim Zahlen Ausgeben");
            var primeNumbers = new PrimeNumbers();
            primeNumbers.Game();
            Console.Clear();
        }
        private static void BitConverterF()
        {
            Console.Clear();
            PrintHeadline("8 Bit Zahlen Konvertieren");
            var bitConverter = new MyBitConverter();
            bitConverter.Game();
            Console.Clear();
        }

    }




    /*private static void ReversingString()
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

    private static void ConvertByte()
    {
        while (true)
        {
            byte value = GetByte();

            Console.WriteLine(value);
            Console.WriteLine(PrimeNumbers.ConvertNumberInto8Bit(value));
        }
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
        }*/
}

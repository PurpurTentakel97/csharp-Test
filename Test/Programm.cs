/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Main
 * C# v. 10.0
 */

using Menues;
using Numbers;
using Strings;

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
            ("Sätze umdrehen",ReverseStringF),
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
        private static void ReverseStringF()
        {
            Console.Clear();
            PrintHeadline("Sätze umdrehen");
            var reverseString = new ReverseString();
            reverseString.Game();
            Console.Clear();
        }

    }
}

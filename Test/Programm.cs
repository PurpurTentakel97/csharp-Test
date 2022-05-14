/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Main
 * C# v. 10.0
 */

using Dictionaries;
using Helpers;
using Menues;
using Numbers;
using Strings;
using Tree;

namespace Test
{
    class Programm
    {
        static Menue menue;
        public static (string, Action)[] menueValue = new (string, Action)[]
        {
            ("Zahlen raten",GuessingNumbersF),
            ("Gerade zahlen anzeigen",EvenNumbersF),
            ("Prim Zahlen bis x",PrimeNumbersF),
            ("Zahlen zu Bit convertieren",BitConverterF),
            ("Sätze umdrehen",ReverseStringF),
            ("Weihnachtsbaum zeichnen",ChristmasTreeF),
            ("Wörterbuch Liste",DictionaryListF),
            ("Wörterbuch Dict",DictionaryDictF),
         };

        static void Main(string[] args)
        {
            menue = new Menue("Hauptmenü", menueValue);
            while (true)
            {
                menue.Print();
                var action = menue.GetAction();
                action();
            }
        }

        private static void GuessingNumbersF()
        {
            Helper.PrintHeadline("Zahlen-Raten_Spiel");
            var guessNumbers = new GuessNumber();
            guessNumbers.Game();
        }
        private static void EvenNumbersF()
        {
            Helper.PrintHeadline("Zahlen-Raten_Spiel");
            var evenNumebrs = new EvenNumbers(menue);
            evenNumebrs.Game();
        }
        private static void PrimeNumbersF()
        {
            Helper.PrintHeadline("Prim Zahlen Ausgeben");
            var primeNumbers = new PrimeNumbers();
            primeNumbers.Game();
        }
        private static void BitConverterF()
        {
            Helper.PrintHeadline("8 Bit Zahlen Konvertieren");
            var bitConverter = new MyBitConverter();
            bitConverter.Game();
        }
        private static void ReverseStringF()
        {
            Helper.PrintHeadline("Sätze umdrehen");
            var reverseString = new ReverseString();
            reverseString.Game();
        }
        private static void ChristmasTreeF()
        {
            Helper.PrintHeadline("Weihnachtsbaum");
            var christmasTree = new ChristmasTree();
            christmasTree.Game();
        }
        private static void DictionaryListF()
        {
            Helper.PrintHeadline("Wörterbuch");
            var myDictionary = new MyDictionarryList(menue);
            myDictionary.Game();
        }
        private static void DictionaryDictF()
        {
            Helper.PrintHeadline("Wörterbuch");
            var myDictionary = new MyDictionarryDict(menue);
            myDictionary.Game();
        }
    }
}

/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Main
 * C# v. 10.0
 */

using Dictionaries;
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
            ("Effiziernte-Prim Zahlen bis x",EfficientPrimeNumbersF),
            ("Zahlen zu Bit convertieren",BitConverterF),
            ("Arithmetischer Mittelwert berechnen",MeanF),
            ("Collatz Problem anzeigen",CollatzF),
            ("Zahlenliste sortieren",SortNumbersF),
            ("Temperatur",TemperatureF),
            ("Sätz Spiele",StringGameF),
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
                if (action == null)
                {
                    break;
                }
                action();
            }
            Console.WriteLine("closing...");
        }

        private static void GuessingNumbersF()
        {
            var guessNumbers = new GuessNumber();
            guessNumbers.Game();
        }
        private static void EvenNumbersF()
        {
            var evenNumebrs = new EvenNumbers();
            evenNumebrs.Game();
        }
        private static void PrimeNumbersF()
        {
            var primeNumbers = new PrimeNumbers();
            primeNumbers.Game();
        }
        private static void EfficientPrimeNumbersF()
        {
            EffiicentPrimeNumbers.Game();
        }
        private static void BitConverterF()
        {
            var bitConverter = new MyBitConverter();
            bitConverter.Game();
        }
        private static void MeanF()
        {
            Mean.Game();
        }
        private static void CollatzF()
        {
            Collatz.Game();
        }
        private static void SortNumbersF()
        {
            SortNumbers.Game();
        }
        private static void TemperatureF()
        {
            Temperature.Game();
        }
        private static void StringGameF()
        {
            var stringGame = new StringGame();
            stringGame.Game();
        }
        private static void ChristmasTreeF()
        {
            var christmasTree = new ChristmasTree();
            christmasTree.Game();
        }
        private static void DictionaryListF()
        {
            var myDictionary = new MyDictionarryList();
            myDictionary.Game();
        }
        private static void DictionaryDictF()
        {
            var myDictionary = new MyDictionarryDict();
            myDictionary.Game();
        }
    }
}



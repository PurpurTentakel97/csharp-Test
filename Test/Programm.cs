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
            ("Zahlen Spiele",NumberGameF),
            ("Sätz Spiele",StringGameF),
            ("Weihnachtsbaum zeichnen",ChristmasTreeF),
            ("Wörterbuch Liste",DictionaryListF),
            ("Wörterbuch Dict",DictionaryDictF),
            ("Sport Bet",SportBetF),
            ("Game Object",GameObjectF),
            ("TicTacToe",TicTacToeF),
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

        private static void NumberGameF()
        {
            var numberGame = new NumberGame();
            numberGame.Game();
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
        private static void SportBetF()
        {
            var sportBet = new SportBet();
            sportBet.Game();
        }
        private static void GameObjectF()
        {
            var game = new GameObject.TestGame();
            game.Game();
        }
        private static void TicTacToeF()
        {
            var game = new TicTacToe.TestGame();
            game.Game();
        }
    }
}



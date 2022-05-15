/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Strings
 */

using Helpers;
using Menues;

namespace Strings
{
    internal class StringGame
    {
        private static Dictionary<string, string> entries = new Dictionary<string, string>();
        private static (string, Action)[] menueValue = new (string, Action)[]
        {
            ("Sätze umdrehen", ReverseStringF),
            ("Liste einzeln ausgeben", StringListF),
            ("Liste einzeln ausgeben ohne Leerzeilen", StringListOutBlankF),
            ("Liste einlesen ohne Schleife", StringSplitF),
            ("Liste einlesen ohne Schleife und convertiertem Array" ,StringSplitAndConvertF),
            ("Liste einlesen ohne Schleife und convertiertem Array mit Methode", StringSplitAndConvertWithMethodF),
        };
        public void Game()
        {
            Menue menue = new Menue("Satz Spiele", menueValue);
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

        private static void ReverseStringF()
        {
            var reverseString = new ReverseString();
            reverseString.Game();
        }
        private static void StringListF()
        {
            var stringList = new StringList();
            stringList.Game();
        }
        private static void StringListOutBlankF()
        {
            var stringListOutBlank = new StringListOutBlank();
            stringListOutBlank.Game();
        }
        private static void StringSplitF()
        {
            var stringSplit = new StringSplit();
            stringSplit.Game();
        }
        private static void StringSplitAndConvertF()
        {
            var stringSplitAndConvert = new StringSplitAndConvert();
            stringSplitAndConvert.Game();
        }
        private static void StringSplitAndConvertWithMethodF()
        {
            var stringSplitAndConvertWithMethod = new StringSplitAndConvertWithMethod();
            stringSplitAndConvertWithMethod.Game();
        }

        internal class ReverseString
        {
            public void Game()
            {
                while (true)
                {
                    Helper.PrintHeadline("Sätze umdrehen");

                    string value = Helper.GetString("Gib einen Satz ein.");
                    PrintReversedString(value);

                    string quitInput = Helper.GetQuitInput();
                    if (quitInput == "q")
                    {
                        break;
                    }
                }
            }

            private void PrintReversedString(string value)
            {
                char[] chars = value.ToCharArray();
                Array.Reverse(chars);
                Console.WriteLine(new string(chars));
            }
        }

        internal class StringList
        {

            public void Game()
            {
                while (true)
                {
                    Helper.PrintHeadline("Sätze umdrehen");

                    string value = Helper.GetString("Gib duch Kommata separierte Werte ein:");
                    string[] values = GetStringArray(value);
                    PrintStringArray(values);

                    string quitInput = Helper.GetQuitInput();
                    if (quitInput == "q")
                    {
                        break;
                    }
                }
            }

            private string[] GetStringArray(string value)
            {
                int counter = 0;
                foreach (char character in value)
                {
                    if (character.Equals(','))
                    {
                        counter++;
                    }
                }
                counter++;

                string[] values = new string[counter];

                int counter2 = 0;
                string toArray = "";
                foreach (char character in value)
                {
                    if (counter2 + 1 == counter)
                    {
                        toArray += character;
                        values[counter2] = toArray;
                        continue;
                    }

                    if (character.Equals(','))
                    {
                        values[counter2] = toArray;
                        toArray = "";
                        counter2++;
                        continue;
                    }

                    toArray += character;
                }

                return values;
            }
            private void PrintStringArray(string[] values)
            {
                foreach (string value in values)
                {
                    Console.WriteLine(value);
                }
            }
        }
        internal class StringListOutBlank
        {

            public void Game()
            {
                while (true)
                {
                    Helper.PrintHeadline("Sätze umdrehen");

                    string value = Helper.GetString("Gib duch Kommata separierte Werte ein:");
                    string[] values = GetStringArray(value);
                    PrintStringArray(values);

                    string quitInput = Helper.GetQuitInput();
                    if (quitInput == "q")
                    {
                        break;
                    }
                }
            }

            private string[] GetStringArray(string value)
            {
                int counter = 0;
                foreach (char character in value)
                {
                    if (character.Equals(','))
                    {
                        counter++;
                    }
                }
                counter++;

                string[] values = new string[counter];

                int counter2 = 0;
                string toArray = "";
                foreach (char character in value)
                {
                    if (counter2 + 1 == counter)
                    {
                        toArray += character;
                        values[counter2] = toArray;
                        continue;
                    }

                    if (character.Equals(','))
                    {
                        values[counter2] = toArray;
                        toArray = "";
                        counter2++;
                        continue;
                    }

                    toArray += character;
                }

                return values;
            }
            private void PrintStringArray(string[] values)
            {
                foreach (string value in values)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        continue;
                    }
                    Console.WriteLine(value);
                }
            }
        }
        internal class StringSplit
        {
            public void Game()
            {
                while (true)
                {
                    Helper.PrintHeadline("Sätze umdrehen");

                    string value = Helper.GetString("Gib duch Kommata separierte Werte ein:");
                    string[] values = GetStringArray(value);
                    PrintStringArray(values);

                    string quitInput = Helper.GetQuitInput();
                    if (quitInput == "q")
                    {
                        break;
                    }
                }
            }
            private string[] GetStringArray(string value)
            {
                string[] values = value.Split(',');
                return values;
            }
            private void PrintStringArray(string[] values)
            {
                foreach (string value in values)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        continue;
                    }
                    Console.WriteLine(value);
                }
            }
        }
        internal class StringSplitAndConvert
        {
            public void Game()
            {
                while (true)
                {
                    Helper.PrintHeadline("Sätze umdrehen");

                    string value = Helper.GetString("Gib duch Kommata separierte Werte ein:");
                    string[] values = GetStringArray(value);
                    PrintStringArray(values);

                    string quitInput = Helper.GetQuitInput();
                    if (quitInput == "q")
                    {
                        break;
                    }
                }
            }
            private string[] GetStringArray(string value)
            {
                string[] values = value.Split(',');
                return values;
            }
            private void PrintStringArray(string[] values)
            {
                string toPrint = "";
                foreach (string value in values)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        continue;
                    }

                    toPrint += value;
                    toPrint += "\n";
                }

                toPrint = toPrint.Substring(0, toPrint.Length - 2);
                Console.WriteLine(toPrint);
            }
        }
        internal class StringSplitAndConvertWithMethod
        {
            public void Game()
            {
                while (true)
                {
                    Helper.PrintHeadline("Sätze umdrehen");

                    string value = Helper.GetString("Gib duch Kommata separierte Werte ein:");
                    string[] values = GetStringArray(value);
                    PrintStringArray(values);

                    string quitInput = Helper.GetQuitInput();
                    if (quitInput == "q")
                    {
                        break;
                    }
                }
            }
            private string[] GetStringArray(string value)
            {
                string[] values = value.Split(',');
                return values;
            }
            private void PrintStringArray(string[] values)
            {
                string toPrint = String.Join("\n", values);
                Console.WriteLine(toPrint);
            }
        }
    }

}
